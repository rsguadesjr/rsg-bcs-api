using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Linq;

namespace BCSProjectAPI.BusinessLayer.Manager
{
    public class UserManager
    {
        public User Login(string username, string password)
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.User.SingleOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                        && x.Password.Equals(password));
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
