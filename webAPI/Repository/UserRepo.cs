using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models;

namespace webAPI.Repository
{
    public class UserRepo : IUser<UserTable>
    {
         GreenWashEntities1 _entities;
       
        public UserRepo(GreenWashEntities1 entities)
        {
            _entities = entities;
        }
        //method to add user
        #region
        public void AddUser(UserTable newuser)
        {
            _entities.UserTables.Add(newuser);
            _entities.SaveChanges();
        }
        #endregion

        //method to delete user
        #region
        public void DeleteUser(int id)
        {
            UserTable Ut = _entities.UserTables.Find(id);
            _entities.UserTables.Remove(Ut);
            _entities.SaveChanges();

        }
        #endregion

        //method to get all the user details
        #region
        public IEnumerable<UserTable> Get()
        {
            return _entities.UserTables.ToList();
        }
        #endregion

        public UserTable GetById(int id)
        {
            return _entities.UserTables.Find(id);
        }
        //method to update the user
        #region
        public void UpdateUser(int id, UserTable user)
        {
            var Ut = _entities.UserTables.Find(id);
            Ut.PhNumber = user.PhNumber;
            Ut.LastName = user.LastName;
            Ut.FirstName = user.FirstName;
            Ut.Email = user.Email;
            Ut.Password = user.Password;
            Ut.Status = user.Status;
            Ut.Role = user.Role;
            _entities.Entry(Ut).State = System.Data.Entity.EntityState.Modified;
            _entities.SaveChanges();

        }
        #endregion
    }
}