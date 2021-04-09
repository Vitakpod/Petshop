using Petshop.DAL.Entities;
using Petshop.DAL.Interfaces;
using Petshop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Petshop.DAL.Repositories
{
    public class ShopUnitOfWork : IUnitOfWork
    {
        private PetContext db;
        private PetRepository petRepository;
        private OrderRepository orderRepository;

        public ShopUnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetContext>();

            var options = optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=petwebappdb;Trusted_Connection=True;")
                    .Options;

            db = new PetContext(options);
        }
        public IRepository<Pet> Pets
        {
            get
            {
                if (petRepository == null)
                    petRepository = new PetRepository(db);
                return petRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
