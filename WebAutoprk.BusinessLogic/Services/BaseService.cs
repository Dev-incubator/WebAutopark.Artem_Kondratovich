using AutoMapper;
using System.Collections.Generic;
using WebAutopark.Core.Interfaces;

namespace WebAutopark.BusinessLogic.Services
{
    public abstract class BaseService<TDto, TEntity> : IDataService<TDto>
        where TDto : class
        where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IMapper mapper, IRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(TDto item)
        {
            var entityItem = _mapper.Map<TEntity>(item);
            _repository.Create(entityItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TDto> GetAllItems()
        {
            var entities = _repository.GetAllItems();
            var dtoItems = _mapper.Map<IEnumerable<TDto>>(entities);
            return dtoItems;
        }

        public TDto GetItem(int id)
        {
            var entityItem = _repository.GetItem(id);
            var dtoItem = _mapper.Map<TDto>(entityItem);
            return dtoItem;
        }

        public void Update(TDto item)
        {
            var entityItem = _mapper.Map<TEntity>(item);
            _repository.Update(entityItem);
        }
    }
}
