using Http_Trigger_Github.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.DAL.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }
}
