using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDAL_Base<T>
    {
        List<T> GetAll();

        List<T> GetbyId(int Id);

        T UpdateEntity(T Entity);

        T CreateEntity(T Entity);

        bool DeleteEntity(int Id);
    }
}
