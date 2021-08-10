using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ASM.Share.Models;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangController : Controller
    {

        private readonly IKhachhangSvc _KhachhangSvc;
        public KhachhangController(IKhachhangSvc KhachhangSvc)
        {
            _KhachhangSvc = KhachhangSvc;
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostKhachhang(Khachhang khachhang)
        {
            try
            {
                int id = await _KhachhangSvc.AddKhachhangAsync(khachhang);
                khachhang.KhachhangID = id;
            }
            catch (Exception ex)
            {

               //return badRequest(-1)
            }
            return Ok(1);
            
        }
    }
}
