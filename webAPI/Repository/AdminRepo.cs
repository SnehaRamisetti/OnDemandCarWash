using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models;

namespace webAPI.Repository
{
    public class AdminRepo
    {
        private readonly GreenWashEntities1 entities;
        public AdminRepo()
        {
            entities = new GreenWashEntities1();
        }
        public AdminRepo(GreenWashEntities1 _aGWE)
        {
            entities = _aGWE;
        }

        //public void AddAdmin(Admin A)
        //{
        //    entities.Admins.Add(A);
        //    entities.SaveChanges();
        //}

        //public void DeleteAdmin(int id)
        //{
        //    Admin ad = entities.Admins.Find(id);
        //    entities. Admins.Remove(ad);
        //    entities.SaveChanges();

        //}

        public IEnumerable<Admin> Get()
        {
            return entities.Admins.ToList();
        }

        //public Admin GetById(int id)
        //{
        //    return entities.Admins.Find(id);
        //}

        //public void UpdateAdmin(int id, Admin AD)
        //{
        //    var Ut = entities.Admins.Find(id);
           
        //    Ut.Email = AD.Email;
        //    Ut.Password = AD.Password;
        //    entities.Entry(Ut).State = System.Data.Entity.EntityState.Modified;
        //    entities.SaveChanges();

        //}
    }
}