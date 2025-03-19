using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T, ID> where T : class
    {
        void Add(T obj);

        void Update(ID id, T obj);

        void Delete(ID id);

        List<T> GetAll();

        T? GetById(ID id);
    }
}
