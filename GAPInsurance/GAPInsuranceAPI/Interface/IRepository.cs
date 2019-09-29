using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetById(int id);
        T Insert(T obj);
        T Update(T obj);
        bool Delete(int id);

    }
}
