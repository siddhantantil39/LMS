using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Data
{
    public class ProfileRepository:BaseRepository
    {

        public List<CustomerInfo> GetAllProfiles()
        {
            return _dbcontext.CustomerInfos.ToList();
        }

        public CustomerInfo? GetProfileById(int id)
        {
            return _dbcontext.CustomerInfos.Find(id);
        }

        public CustomerInfo AddCustomer(int id,string custname,string email,string pan,string phoneno,string custAddress)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.Id = id;
            customerInfo.Custname = custname;
            customerInfo.Email = email;
            customerInfo.Pan = pan;
            customerInfo.Phoneno = phoneno;
            customerInfo.CustAddress = custAddress;
            _dbcontext.Add(customerInfo);
            _dbcontext.SaveChanges();
            return customerInfo;
        }
    }
}
