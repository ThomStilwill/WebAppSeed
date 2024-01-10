using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ICommonRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);
        Task<T> Add(T toCreate);

        Task<T> Update(int id, T tObject);

        Task Delete(int id);
    }
}
