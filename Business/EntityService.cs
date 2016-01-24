using System;
using System.Collections.Generic;
using DataAccess;

namespace Business
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private IGenericRepository<T> repository;
        private IUnitOfWork unitOfWork;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public virtual void Create(T entity)
        {
            CheckActionSaveEntity(() => repository.Add(entity), entity);
        }

        public virtual void Delete(T entity)
        {
            CheckActionSaveEntity(() => repository.Delete(entity), entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public virtual void Update(T entity)
        {
            CheckActionSaveEntity(() => repository.Edit(entity), entity);
        }

        protected void CheckEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
        }

        protected void Save()
        {
            unitOfWork.Commit();
        }

        private void CheckActionSaveEntity(Action action, T entity)
        {
            CheckEntity(entity);
            action();

            Save();
        }
    }
}