using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repository
{
    internal interface IAdmin<TEntity>
    {
        IEnumerable<TEntity> Get();

        //Admin GetById(int id);
        //void DeleteAdmin(int id);

        //void UpdateAdmin(int id, Admin A);

        //void AddAdmin(TEntity A);
    }
}
