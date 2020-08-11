using System;
using System.Collections.Generic;
using System.Text;

namespace LayeredShop.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IServiceRepository Service { get; }
        void Save();
    }
}
