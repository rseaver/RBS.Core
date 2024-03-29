using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using StructureMap;

namespace RBS.Core.Domain.Tools
{
    public class Repository : IRepository
    {
        private readonly IContainer _container;
        private IUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
            set { _unitOfWork = value; }
        }

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.Initialize();
        }

        public void DisableFilter(string FilterName)
        {
            _unitOfWork.DisableFilter(FilterName);
        }

        public void EnableFilter(string FilterName, string field, object value)
        {
            _unitOfWork.EnableFilter(FilterName, field, value);
        }

        public ISession CurrentSession()
        {
            return _unitOfWork.CurrentSession;
        }

        public void Save<ENTITY>(ENTITY entity) where ENTITY : Entity
        {
            _unitOfWork.CurrentSession.SaveOrUpdate(entity);
        }

        public IEnumerable<T> FindAll<T>() where T : Entity
        {
            return _unitOfWork.CurrentSession.Query<T>();
        }

        public void Delete<ENTITY>(ENTITY entity) where ENTITY : Entity
        {
            _unitOfWork.CurrentSession.Delete(entity);
        }

        public void HardDelete(object target)
        {
            _unitOfWork.CurrentSession.Delete(target);
        }

        public ENTITY Load<ENTITY>(int id) where ENTITY : Entity
        {
            return _unitOfWork.CurrentSession.Load<ENTITY>(id);
        }

        public IQueryable<ENTITY> Query<ENTITY>() where ENTITY : Entity
        {
            return _unitOfWork.CurrentSession.Query<ENTITY>();
        }

        public IQueryable<ENTITY> Query<ENTITY>(Expression<Func<ENTITY, bool>> where)
        {
            return _unitOfWork.CurrentSession.Query<ENTITY>().Where(where);
        }

        public T FindBy<T>(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.CurrentSession.Query<T>().FirstOrDefault(where);
        }

        public T Find<T>(int id) where T : Entity
        {
            return _unitOfWork.CurrentSession.Get<T>(id);
        }

        public IList<ENTITY> ExecuteCriteria<ENTITY>(DetachedCriteria criteria) where ENTITY : Entity
        {
            ICriteria executableCriteria = criteria.GetExecutableCriteria(_unitOfWork.CurrentSession);
            return executableCriteria.List<ENTITY>();
        }

        public IList<T> GetNamedQuery<T>(string sprocName)
        {
            return _unitOfWork.CurrentSession.GetNamedQuery(sprocName).List<T>();
        }

        public IQueryOver<ENTITY> QueryOver<ENTITY>() where ENTITY : Entity
        {
            return _unitOfWork.CurrentSession.QueryOver<ENTITY>();
        }

        public void Initialize()
        {
            _unitOfWork.Initialize();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}