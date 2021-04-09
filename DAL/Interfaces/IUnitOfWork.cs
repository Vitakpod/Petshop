using Petshop.DAL.Entities;
using System;

namespace Petshop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Pet> Pets { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }

}
