
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Data
{
    public class ProfileRepository : BaseRepository
    {

        public List<CustomerInfo> GetAllProfiles()
        {
            return _dbcontext.CustomerInfos.ToList();
        }

        public CustomerInfo? GetProfileById(int id)
        {
            return _dbcontext.CustomerInfos.Find(id);
        }

        public CustomerInfo AddCustomer(CustomerInfo customer)
        {

            _dbcontext.Add(customer);
            _dbcontext.SaveChanges();
            return customer;
        }
    }
}

    