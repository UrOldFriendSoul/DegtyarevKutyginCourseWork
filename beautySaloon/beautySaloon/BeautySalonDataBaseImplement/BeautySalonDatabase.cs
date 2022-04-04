using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeautySalonDataBaseImplement.Models;

namespace BeautySalonDataBaseImplement
{
    public class BeautySalonDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-B2TPTK14\SQLEXPRESS;Initial Catalog=BeautySalonDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Cosmetic> Cosmetics { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Estimate> Estimates { get; set; }

        public virtual DbSet<LaborCosts> LaborCosts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Procedure> Procedures { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<ServicesInOrder> ServicesInOrders { get; set; }

        public virtual DbSet<CosmeticsInOrder> CosmeticsInOrders { get; set; }

        public virtual DbSet<ResponsibleEmployee> ResponsibleEmployees { get; set; }

        public virtual DbSet<ProcedureMarks> ProcedureMarks { get; set; }

    }
}
