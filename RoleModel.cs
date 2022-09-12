using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodFranchis.Model
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
