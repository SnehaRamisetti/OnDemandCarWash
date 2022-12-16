using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models;

namespace webAPI.Repository
{
    public class PackageRepo : IUser<Package>
    {
        GreenWashEntities1 _entities;
        public PackageRepo(GreenWashEntities1 entities)
        {
            _entities = entities;
        }

        public void AddUser(Package package)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Package> Get()
        {
            return _entities.Packages.ToList();
        }

        public UserTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int id, Package user)
        {
            throw new NotImplementedException();
        }

        Package IUser<Package>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}