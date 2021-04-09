using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Petshop.DAL.Entities;
using Petshop.DAL.Interfaces;
using Petshop.DAL.Context;
using System.Threading.Tasks;

namespace Petshop.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private PetContext db;

        public OrderRepository(PetContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Pet);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Pet).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }

    }
}
