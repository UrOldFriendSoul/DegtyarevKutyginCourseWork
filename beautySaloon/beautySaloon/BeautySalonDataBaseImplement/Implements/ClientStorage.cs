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
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Clients
                .Select(CreateModel)
                .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Clients
            .Include(rec => rec.Orders)
            .Include(rec => rec.Procedures)
            .Where(rec => rec.Login == model.Login)
            .Select(CreateModel)
            .ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var client = context.Clients
            .Include(rec => rec.Orders)
            .Include(rec => rec.Procedures)
            .FirstOrDefault(rec => rec.Login == model.Login || rec.Id == model.Id);
            return client != null ? CreateModel(client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Clients.Add(CreateModel(model, new Client()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ClientBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Client CreateModel(ClientBindingModel model, Client client)
        {
            client.FIOClient = model.FIOClient;
            client.Login = model.Login;
            client.Password = model.Password;
            return client;
        }
        private static ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                FIOClient = client.FIOClient,
                Login = client.Login,
                Password = client.Password
            };
        }
    }
}
