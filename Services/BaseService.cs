using Assignment1.Repository;

namespace Assignment1.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<T>> GetAllAsync() => _repository.GetAllAsync();
        public Task<T?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(T entity) => _repository.AddAsync(entity);
        public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
