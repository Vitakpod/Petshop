using Petshop.BLL.DTO;
using Petshop.BLL.Interfaces;
using Petshop.DAL.Interfaces;
using Petshop.DAL.Entities;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace Petshop.BLL.Services
{
    public class ShopService: IShopService
    {
        IUnitOfWork Database { get; set; }

        public ShopService (IUnitOfWork uow)
        {
            Database = uow;
        }
        int orderIdCounter = 0;
        int petIdCounter = 0;
        public void MakeOrder(OrderDTO orderDto)
        {
            Pet pet = Database.Pets.Get(orderDto.PetId);

            if (pet == null)
                throw new ValidationException("Животное не найдено!", "");

            Order order = new Order
            {
                Date = DateTime.Now,
                CustomerName = orderDto.CustomerName,
                PetId = pet.Id,
                PhoneNumber = orderDto.PhoneNumber,
                Id = orderIdCounter,
                Sum = orderDto.Sum
            };
            pet.Orders = (ICollection<Order>)order;
            orderIdCounter++;
            Database.Pets.Update(pet);
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<PetDTO> GetPets()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Pet>, List<PetDTO>>(Database.Pets.GetAll());
        }

        public PetDTO GetPet(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var pet = Database.Pets.Get(id.Value);
            if (pet == null)
                throw new InvalidOperationException("Извините, животное не найдено!");

            return new PetDTO { Type = pet.Type, Id = pet.Id, Name = pet.Name, Price = pet.Price };
        }

        public void CreatePet(PetDTO petDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PetDTO, Pet>()).CreateMapper();
            Pet pet = mapper.Map<Pet>(petDTO);
            pet.Id = petIdCounter;
            petIdCounter++;
            Database.Pets.Create(pet);
            Database.Save();
        }

        public IEnumerable<PetDTO> GetFreePets()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetDTO>()).CreateMapper();
            var petDTOs = mapper.Map<IEnumerable<Pet>, List<PetDTO>>(Database.Pets.GetAll());

            var freeDTOs = new List<PetDTO>();
            foreach (PetDTO dto in petDTOs)
            {
                if (dto.Orders == null)
                    freeDTOs.Add(dto);
            }
            return freeDTOs;
        }

        public OrderDTO GetOrders(int? OrderId)
        {
            if (OrderId == null)
                throw new ArgumentNullException(nameof(OrderId));

            var order = Database.Orders.Get(OrderId.Value);
            if (order == null)
                throw new InvalidOperationException("Извините, Ваш заказ не найден!");

            return new OrderDTO { Id = order.Id, Sum = order.Sum, PhoneNumber = order.PhoneNumber, 
                CustomerName = order.CustomerName, PetId = order.PetId, Date = order.Date };
        }
        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
