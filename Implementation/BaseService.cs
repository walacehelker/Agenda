using AutoMapper;
using Context;
using Dados;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace Implementation
{
    public class BaseService<TBaseEntity, TBaseVmEntity> : IBaseService<TBaseVmEntity> where TBaseEntity : Base, new() where TBaseVmEntity : BaseVm, new()
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BaseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DbSet<TBaseEntity> GetDbSet()
        {
            return _dbContext.Set<TBaseEntity>();
        }

        public List<TBaseVmEntity> ListAll()
        {
            var entities = GetDbSet().ToList();
            return _mapper.Map<List<TBaseVmEntity>>(entities);
        }

        public async Task<List<TBaseVmEntity>> ListAllAsync()
        {
            var entities = await GetDbSet().Where(e => !e.Excluido).ToListAsync();
            return _mapper.Map<List<TBaseVmEntity>>(entities);
        }

        public virtual TBaseVmEntity GetById(string id)
        {
            var dbSet = GetDbSet();
            var entity = dbSet.Find(id);
            return _mapper.Map<TBaseVmEntity>(entity);
        }

        public async virtual Task<TBaseVmEntity> GetByIdAsync(string id)
        {
            var dbSet = GetDbSet();
            var entity = await dbSet.FindAsync(id);
            return entity != null && !entity.Excluido ? _mapper.Map<TBaseVmEntity>(entity) : null;
        }

        public virtual void Add(TBaseVmEntity TBaseVmEntity)
        {
            TBaseVmEntity.DataCadastro = DateTime.Now;
            var entity = _mapper.Map<TBaseEntity>(TBaseVmEntity);

            GetDbSet().Add(entity);
            _dbContext.SaveChanges();
        }

        public async virtual Task AddAsync(TBaseVmEntity TBaseVmEntity)
        {
            TBaseVmEntity.DataCadastro = DateTime.Now;
            var entity = _mapper.Map<TBaseEntity>(TBaseVmEntity);

            await GetDbSet().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Update(TBaseVmEntity TBaseVmEntity)
        {
            var existingEntity = GetDbSet().Find(TBaseVmEntity.Id);
            _mapper.Map(TBaseVmEntity, existingEntity);

            GetDbSet().Update(existingEntity);
            _dbContext.SaveChanges();
        }

        public async virtual Task UpdateAsync(TBaseVmEntity TBaseVmEntity)
        {
            var existingEntity = await GetDbSet().FindAsync(TBaseVmEntity.Id);
            _mapper.Map(TBaseVmEntity, existingEntity);

            GetDbSet().Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual void DeleteById(string id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                entity.Excluido = true;
                entity.DataExclusao = DateTime.Now;

                Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public async virtual Task DeleteByIdAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.Excluido = true;
                entity.DataExclusao = DateTime.Now;

                await UpdateAsync(entity);
                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
