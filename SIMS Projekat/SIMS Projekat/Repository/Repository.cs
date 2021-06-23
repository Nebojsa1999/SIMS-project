using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_Projekat.Core;
using SIMS_Projekat.Model;

namespace SIMS_Projekat.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(Entity entity)
        {
            ModelContext.Instance.Get(typeof(TEntity)).Add(entity);
        }

        public Entity Get(string id)
        {
            return ModelContext.Instance.Get(typeof(TEntity)).Where(x => x.ID == id).FirstOrDefault();
        }

        public IEnumerable<Entity> GetAll()
        {
            return ModelContext.Instance.Get(typeof(TEntity));
        }

        public void Remove(Entity entity)
        {
            Entity entityToRemove = Get(entity.ID);
            ModelContext.Instance.Get(typeof(TEntity)).Remove(entityToRemove);
        }

        public virtual IEnumerable<Entity> Search(string term = "")
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            ModelContext.Instance.Save();
        }

    }
}
