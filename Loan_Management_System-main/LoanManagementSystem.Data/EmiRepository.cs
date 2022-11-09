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

        public Emi AddEmi(Emi emi)
        {
            _dbcontext.Emis.Add(emi);
            _dbcontext.SaveChanges();
            return emi;
        }

        public bool CompleteEmi(Emi emi)
        {
            emi = _dbcontext.Emis.Find(emi.Id);
            if(emi == null)
            {
                return false;
            }
            emi.EmiCompleted = true;
            _dbcontext.Update(emi);
            _dbcontext.SaveChanges();
            return true;
        }
    }
}
