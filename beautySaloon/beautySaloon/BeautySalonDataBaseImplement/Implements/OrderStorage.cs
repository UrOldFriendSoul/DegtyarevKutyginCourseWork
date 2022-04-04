using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using BeautySalonContracts.BindingModels;
using BeautySalonDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySalonDataBaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Orders.Select(CreateModel).ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Orders
                .Where(rec => rec.FIOClient == model.FIOClient
                && rec.ServiceName == model.ServiceName
                && rec.RegistrationDate >= model.DateFrom && rec.RegistrationDate <= model.DateTo)
                .Select(CreateModel).ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var orders = context.Orders.FirstOrDefault(rec => rec.OrderName == model.OrderName || rec.Id == model.Id);
            return orders != null ? CreateModel(orders) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Order orders = new Order()
                {
                    OrderName = model.OrderName,
                    Price = model.Price
                };
                context.Orders.Add(orders);
                context.SaveChanges();
                CreateModel(model, orders, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(OrderBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Order CreateModel(OrderBindingModel model, Order order, BeautySalonDatabase context)
        {
            order.ServiceName = model.ServiceName;
            if (model.Id.HasValue)
            {
                var ServiceServices = context.ServicesInOrders.Where(rec => rec.Id == model.Id.Value).ToList();
                context.ServicesInOrders.RemoveRange(ServiceServices.Where(rec => !model.ServicesInOrders.ContainsKey(rec.ServiceId)).ToList());
                context.SaveChanges();
                foreach (var updateService in ServiceServices)
                {
                    model.ServicesInOrders.Remove(updateService.ServiceId);
                }
                context.SaveChanges();
            }

            foreach (var pc in model.ServicesInOrders)
            {
                context.ServicesInOrders.Add(new ServicesInOrder
                {
                    Id = order.Id,
                    ServiceId = pc.Key
                });
                context.SaveChanges();
            }
            return order;
        }

        private static OrderViewModel CreateModel(Order orders)
        {
            using var context = new BeautySalonDatabase();
            int? OrderId = context.Orders.FirstOrDefault(rec => rec.Id == orders.Id)?.Id;
            return new OrderViewModel
            {
                Id = orders.Id,
                OrderName = orders.OrderName,
                FIOClient = context.Orders.FirstOrDefault(rec => rec.OrderName == orders.OrderName)?.FIOClient,
                Price = orders.Price,
                ServiceName = context.Services.FirstOrDefault(rec => rec.Id == orders.Id)?.ServiceName,
                RegistrationDate = orders.RegistrationDate
            };
        }
    }
}
