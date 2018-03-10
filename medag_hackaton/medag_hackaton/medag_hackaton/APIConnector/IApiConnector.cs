using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace medag_hackaton.APIConnector
{
    public interface IApiConnector<Tkey,TEntity>
    {
        Task<TEntity> Get(Tkey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<Tkey> Insert(TEntity entity);
    }
}
