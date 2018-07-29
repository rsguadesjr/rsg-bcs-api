using AutoMapper;
using BCSProjectAPI.BusinessLayer.Manager;
using BCSProjectAPI.DataLayer.Dtos;
using BCSProjectAPI.DataLayer.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace BCSProjectAPI.Controllers
{
    public class CharacteristicsController : ApiController
    {
        CharacteristicManager _characteristicManager;

        public CharacteristicsController()
        {
            _characteristicManager = new CharacteristicManager();
        }

        // GET api/chacteristics
        [HttpGet]
        public IHttpActionResult GetCharacteristics()
        {
            var result = _characteristicManager.GetCharacteristics();
            return Ok(result);
        }

        // GET api/chacteristics
        [HttpGet]
        public IHttpActionResult GetCharacteristics(int id)
        {
            var result = _characteristicManager.GetEmployeeCharacteristics(id);
            return Ok((Mapper.Map<List<EmployeeCharacteristic>, List<EmployeeCharacteristicDto>>(result)));
        }
    }
}
