using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All();
        T GetByID(int ID);
        void Create(T Entity);
        void Edit(T Entity);
        void Delete(int ID);
        Task save();

        IEnumerable<T> GetAllEgarLoading(object ob, object obj);

    }
}
