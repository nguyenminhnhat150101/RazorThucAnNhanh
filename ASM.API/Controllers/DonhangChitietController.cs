using ASM.Share.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ASM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangChitietController : ControllerBase
    {
        private readonly IDonhangChitietSvc _donhangChitietSvc;
        private readonly IDonhangSvc _donhangSvc;
        public DonhangChitietController(IDonhangSvc donhangSvc, IDonhangChitietSvc donhangChitietSvc)
        {
            _donhangChitietSvc = donhangChitietSvc;
            _donhangSvc = donhangSvc;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donhang>>> GetDonhang([FromQuery] int id)
        {
            var donhang = await _donhangSvc.GetDonhangAsync(id);
            List<Donhang> list = new List<Donhang>();
            list.Add(donhang);
            return list;
        }
    }
}
