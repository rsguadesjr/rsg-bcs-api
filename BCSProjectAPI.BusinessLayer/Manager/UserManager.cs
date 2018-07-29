using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Linq;

using System.Data.Entity;
using System.Collections.Generic;

namespace BCSProjectAPI.BusinessLayer.Manager
{
    public class UserManager
    {
        public User GetUserCredentials(string username, string password)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var user = db.Users
                            .Include(x => x.Role)
                            .SingleOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                    if (user != null)
                    {
                        if (user.Password == password)
                        {
                            user.LoginAttempt = 0;
                            user.IsLocked = false;
                            db.SaveChanges();
                            return user;
                        }
                        else
                        {
                            ++user.LoginAttempt;
                            user.IsLocked = user.LoginAttempt == Constants.MaxLoginAttemp ? true : false;
                            db.SaveChanges();
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UnlockUser(int userId)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Single(x => x.Id == userId);
                user.LoginAttempt = 0;
                user.IsLocked = false;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return false;
        }


        public List<User> GetUsers()
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.Users.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUser(int id, User user)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var existingUser = db.Users.Single(x => x.Id == id);
                    existingUser.RoleId = user.RoleId;
                    existingUser.EmployeeId = user.RoleId == (int)UserRole.Employee ? user.EmployeeId : null;

                    db.Entry(existingUser).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        public bool CreateUser(User user)
        {
            try
            {
                using (var db = new DataContext())
                {
                    if (user.RoleId != (int)UserRole.Employee)
                        user.EmployeeId = null;

                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
