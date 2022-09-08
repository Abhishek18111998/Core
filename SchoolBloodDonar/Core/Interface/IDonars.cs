using SchoolBloodDonar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBloodDonar.Core.Interface
{
    public interface IDonars
    {
        public Task AddNewDonar(SchoolModel schoolModel);
        public Task<List<SchoolModel>> DisplayAllDonars();
    }
}
