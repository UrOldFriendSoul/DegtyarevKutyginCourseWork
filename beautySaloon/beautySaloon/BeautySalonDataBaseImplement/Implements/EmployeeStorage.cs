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
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Employees
            .Include(rec => rec.ResponsibleEmployees)
            .ThenInclude(rec => rec.Services)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Employees.Where(rec => rec.FIOEmployee == model.FIOEmployee && rec.Services == model.Services).Select(CreateModel).ToList();
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var employee = context.Employees.FirstOrDefault(rec => rec.FIOEmployee == model.FIOEmployee || rec.Id == model.Id);
            return employee != null ? CreateModel(employee) : null;
        }

        public void Insert(EmployeeBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Employee services = new Employee()
                {
                    FIOEmployee = model.FIOEmployee,
                    Services = model.Services
                };
                context.Employees.Add(services);
                context.SaveChanges();
                CreateModel(model, services, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(EmployeeBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(EmployeeBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Employee element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Employees.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Employee CreateModel(EmployeeBindingModel model, Employee employee, BeautySalonDatabase context)
        {
            employee.FIOEmployee = model.FIOEmployee;
            if (model.Id.HasValue)
            {
                var EmployeeEmployees = context.ResponsibleEmployees.Where(rec => rec.Id == model.Id.Value).ToList();
                context.ResponsibleEmployees.RemoveRange(EmployeeEmployees.Where(rec => !model.ResponsibleEmployee.ContainsKey(rec.EmployeeId)).ToList());
                context.SaveChanges();
                foreach (var updateService in EmployeeEmployees)
                {
                    model.ResponsibleEmployee.Remove(updateService.EmployeeId);
                }
                context.SaveChanges();
            }

            foreach (var pc in model.ResponsibleEmployee)
            {
                context.ResponsibleEmployees.Add(new ResponsibleEmployee
                {
                    Id = employee.Id,
                    EmployeeId = pc.Key
                });
                context.SaveChanges();
            }
            return employee;
        }

        private static EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                FIOEmployee = employee.FIOEmployee,
                Services = employee.Services
            };
        }
    }
}
