using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository profileRepository;

        public ProfileService()
        {
            profileRepository = new ProfileRepository();
        }

        public CustomerInfo GetProfileById(int id)
        {
            CustomerInfo profile = profileRepository.GetProfileById(id);
            return profile;
        }

        public List<CustomerInfo> GetAllProfile()
        {
            List<CustomerInfo> profileList = profileRepository.GetAllProfiles();
            return profileList;
        }

        public CustomerInfo AddCustomer(CustomerInfo customer)
        {
            profileRepository.AddCustomer(customer);
            return customer;
        }
    }
}


