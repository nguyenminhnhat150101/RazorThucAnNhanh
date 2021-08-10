using ASM.Share.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangController : ControllerBase
    {
        private readonly IDonhangSvc _donhangSvc;
        public DonhangController(IDonhangSvc donhangSvc)
        {
            _donhangSvc = donhangSvc;
        }
        //Get api/Monan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donhang>>> GetDonhangbyKhachhang([FromQuery] int id)
        {
            return await _donhangSvc.GetDonhangbyKhachhangAsync(id);
        }
    }
}
