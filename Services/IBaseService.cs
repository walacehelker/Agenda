using Models;

namespace Services
{
    public interface IBaseService<TBaseVmEntity> where TBaseVmEntity : BaseVm
    {
        List<TBaseVmEntity> ListAll();
        TBaseVmEntity GetById(string id);
        void Add(TBaseVmEntity pessoa);
        void Update(TBaseVmEntity pessoa);
        void DeleteById(string id);

        // Adicionando métodos assíncronos
        Task<List<TBaseVmEntity>> ListAllAsync();
        Task<TBaseVmEntity> GetByIdAsync(string id);
        Task AddAsync(TBaseVmEntity pessoa);
        Task UpdateAsync(TBaseVmEntity pessoa);
        Task DeleteByIdAsync(string id);
    }
}
