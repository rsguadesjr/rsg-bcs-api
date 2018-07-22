using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Linq;

using System.Data.Entity;

namespace BCSProjectAPI.BusinessLayer.Manager
{
    public class UserManager
    {
        public User GetUser(string username, string password)
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.User
                            .Include(x => x.Role)
                            .SingleOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
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
