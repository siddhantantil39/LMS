using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace LoanManagementSystem.Data
{
    public class EmiRepository:BaseRepository
    {
        public List<Emi> GetAllEMIs()
        {
            return _dbcontext.Emis.Include(emi => emi.LoanType).ToList();
        }

        public Models.Emi GetEMIById(int id)
        {
            return _dbcontext.Emis.Include(emi => emi.LoanType).FirstOrDefault(emi => emi.Id == id);
        }

        public List<Emi> GetEMIByCustId(int id)
        {
            return _dbcontext.Emis.Include(emi => emi.LoanType).Where(emi => emi.Cust.Id == id).ToList(); 
        }

    }
}
