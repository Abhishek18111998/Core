using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBloodDonar.Core.Interface;
using SchoolBloodDonar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBloodDonar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarController : ControllerBase
    {
        private IDonars _donars;
        public DonarController(IDonars donars)
        {
            _donars = donars;
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddingDonar(SchoolModel schoolModel)
        {
            try
            {
                await _donars.AddNewDonar(schoolModel);
                return Ok("Donar Added SuccessFully");
            }
            catch
            {
                return BadRequest("Adding Of Donar Failed");
            }
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> DisplayDonars()
        {
            try
            {
                var donarList = await _donars.DisplayAllDonars();
                if (donarList.Count != 0)
                {
                    return Ok(donarList);
                }
                else
                {
                    return BadRequest("No Donars Available");
                }
            }
            catch
            {
                return BadRequest("Getting Of Donars Failed");
            }
        }
    }
}
