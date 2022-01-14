using System.Collections.Generic;
using WebAutopark.Core.Interfaces;

namespace WebAutoprk.BusinessLogic.Services
{
    public class BaseService<TDto, TEntity> : IDtoService<TDto>
        where TDto : class
        where TEntity : class
    {
        public void Create(TDto item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TDto> GetAllItems()
        {
            throw new System.NotImplementedException();
        }

        public TDto GetItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TDto item)
        {
            throw new System.NotImplementedException();
        }
    }
}
