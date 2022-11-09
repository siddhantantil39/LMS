using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public class EMICalculatorService
    {
        public float Calculate (int months, float amount, float rate)
        {
            float totalAmount = 0;
            float emi;
            float r = rate / (12 * 100);
            emi = (amount * r * (float)Math.Pow(1 + r, months)) / (float)(Math.Pow(1 + r, months) - 1);
            totalAmount = emi * months;
            return totalAmount;
        }
    }
}