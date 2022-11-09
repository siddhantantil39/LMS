using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Data
{
    public class BaseRepository
    {
        protected readonly LMSContext _dbcontext;

        public BaseRepository()
        {
            _dbcontext = new LMSContext(); 
        }
    }
}
