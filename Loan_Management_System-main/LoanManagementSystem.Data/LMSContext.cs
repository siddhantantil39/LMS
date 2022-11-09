using System;
using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LoanManagementSystem.Data
{
    public partial class LMSContext : DbContext
    {
        public LMSContext()
        {
        }

        public LMSContext(DbContextOptions<LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }
        public virtual DbSet<Emi> Emis { get; set; }
        public virtual DbSet<EmiPayment> Emipayments { get; set; }
        public virtual DbSet<LoanApplication> LoanApplications { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=LMS;trusted_connection=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInfo>().HasData(
                    new CustomerInfo 
                    {
                        Id = 1, 
                        Custname = "Test1",
                        Email = "email@email.com",
                        Pan = "6846asdf",
                        Phoneno = "9876543210", 
                        CustAddress = "address"},
                    new CustomerInfo
                    {
                        Id = 2,
                        Custname = "Test2",
                        Email = "email@email.com",
                        Pan = "6846asdf",
                        Phoneno = "9876543210",
                        CustAddress = "address"
                    }
                );

            modelBuilder.Entity<LoanType>().HasData(
                    new LoanType { 
                        Id = 1,
                        LoanTypeName = "Gold_Loan",
                        InterestRate = 10
                    },
                    new LoanType
                    {
                        Id = 2,
                        LoanTypeName = "Home_Loan",
                        InterestRate = 12
                    },
                    new LoanType
                    {
                        Id = 3,
                        LoanTypeName = "Personal_Loan",
                        InterestRate = 8
                    }
                );

            modelBuilder.Entity<LoanApplication>().HasData(
                    new LoanApplication
                    {
                        Id = 1,
                        CustomerInfoId = 1,
                        status = LoanStatus.APPLIED,
                        LoanTypeId = 2,
                        Amount = 1000000,
                        BankDetailId = 1,
                        Months = 12,
                        Interest = 12,
                    },
                    new LoanApplication
                    {
                        Id = 2,
                        CustomerInfoId = 1,
                        status = LoanStatus.APPLIED,
                        LoanTypeId = 3,
                        Amount = 100000,
                        BankDetailId = 2,
                        Months = 24,
                        Interest = 8,
                    }
                ) ;

            modelBuilder.Entity<Emi>().HasData(
                    new Emi { 
                        Id = 1,
                        Amount = 1000000,
                        Interest = 10,
                        LoanTypeId = 1,
                        CustomerInfoId = 1,
                        Months = 12,
                        StartDate = new DateTime(2022, 10, 10)
                    },
                    new Emi
                    {
                        Id = 2,
                        Amount = 5000000,
                        Interest = 10,
                        LoanTypeId = 1,
                        CustomerInfoId = 2,
                        Months = 24,
                        StartDate = new DateTime(2022, 10, 10)
                    }
                );

            modelBuilder.Entity<EmiPayment>().HasData(
                    new EmiPayment
                    {
                        Id = 1,
                        EmiId = 1,
                        EmiAmount = 1000000 / 12,
                        Fine = 0,
                        IssueDate = new DateTime(2022, 11, 10),
                        PaidOn = new DateTime(2022, 11, 1)
                    },
                    new EmiPayment
                    {
                        Id = 2,
                        EmiId = 1,
                        EmiAmount = 1000000 / 12,
                        Fine = 0,
                        IssueDate = new DateTime(2022, 12, 10),
                        PaidOn = new DateTime(2022, 12, 1)
                    },
                    new EmiPayment
                    {
                        Id = 3,
                        EmiId = 2,
                        EmiAmount = 5000000 / 24,
                        Fine = 0,
                        IssueDate = new DateTime(2022, 12, 10),
                        PaidOn = new DateTime(2022, 12, 1)
                    }
                );

            modelBuilder.Entity<BankDetail>().HasData(
                new BankDetail
                {
                    Id = 1,
                    BankAddress = "Test",
                    BankName = "Test"
                },
                new BankDetail
                {
                    Id = 2,
                    BankAddress = "Test",
                    BankName = "Test"
                },
                new BankDetail
                {
                    Id = 3,
                    BankAddress = "Test",
                    BankName = "Test"
                }

            ) ;
            
        }
    }
}
