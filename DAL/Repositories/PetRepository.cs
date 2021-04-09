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
    public class PetRepository : IRepository<Pet>
    {
        private PetContext db;

        public PetRepository(PetContext context)
        {
            this.db = context;
        }

        public IEnumerable<Pet> GetAll()
        {
            return db.Pets;
        }

        public Pet Get(int id)
        {
            return db.Pets.Find(id);
        }

        public void Create(Pet pet)
        {
            db.Pets.Add(pet);
        }

        public void Update(Pet pet)
        {
            db.Entry(pet).State = EntityState.Modified;
        }

        public IEnumerable<Pet> Find(Func<Pet, Boolean> predicate)
        {
            return db.Pets.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet != null)
                db.Pets.Remove(pet);
        }

    }
}
