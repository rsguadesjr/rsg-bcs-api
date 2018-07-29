using AutoMapper;
using BCSProjectAPI.BusinessLayer.Manager;
using BCSProjectAPI.DataLayer.Dtos;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCSProjectAPI.Controllers
{

    public class UsersController : ApiController
    {
        UserManager _userManager;
        public UsersController()
        {
            _userManager = new UserManager();
        }

        // GET api/users
        public IHttpActionResult GetUsers()
        {
            var result = _userManager.GetUsers();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/users/login")]
        public IHttpActionResult Login(User user)
        {
            var userCredential = _userManager.GetUserCredentials(user.Username, user.Password);
            if (userCredential != null && !userCredential.IsLocked)
            {
                //create employeeDto later
                userCredential.Employee = null;
                userCredential.Password = null;

                var test = Mapper.Map<User, UserDto>(userCredential);
                return Ok(test);
            }

            else if (userCredential != null &&  userCredential.IsLocked)
            {
                HttpResponseMessage response = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User account is locked. Please contact administrator.");
                throw new HttpResponseException(response);
            }

            //should move this later
            HttpResponseMessage response2 = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or Password is incorrect.");
            throw new HttpResponseException(response2);
        }

        // POST api/users
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            var saved = _userManager.CreateUser(user);
            if (!saved)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok();
        }

        // PUT api/users
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, User user)
        {
            var saved = _userManager.UpdateUser(id, user);
            if (!saved)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok();
        }
    }
}
