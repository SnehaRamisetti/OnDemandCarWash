using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repository
{
    internal interface IUser<TEntity>
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(int id);
        void DeleteUser(int id);

        void UpdateUser(int id, TEntity user);

        void AddUser(TEntity user);
    }
}
