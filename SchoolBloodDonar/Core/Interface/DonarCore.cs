using Microsoft.EntityFrameworkCore;
using SchoolBloodDonar.DataAccess;
using SchoolBloodDonar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBloodDonar.Core.Interface
{
    public class DonarCore : IDonars
    {
        private DatabaseContext _databaseContext;
        public DonarCore(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task AddNewDonar(SchoolModel schoolModel)
        {
            try
            {
                await _databaseContext.SchoolDonars.AddAsync(schoolModel);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SchoolModel>> DisplayAllDonars()
        {
            try
            {
                return await _databaseContext.SchoolDonars.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
