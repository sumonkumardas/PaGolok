using PaGolok.Data.Repositories;
using PaGolok.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Web.Http;
using PaGolok.Web.Infrastructure.Extensions;
using System.Net.Http;
using PaGolok.Entities.DB_Entity;
using PaGolok.Entities.Base;

namespace PaGolok.Web.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IAuditableEntity, new()
        {
            return request.GetDataRepository<T>();
        }
    }

    public interface IDataRepositoryFactory
    {
        IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IAuditableEntity, new();
    }
}