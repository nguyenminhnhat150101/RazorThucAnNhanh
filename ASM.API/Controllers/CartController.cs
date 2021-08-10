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
    public class CartController : ControllerBase
    {
        private readonly IDonhangSvc _donhangSvc;
        private readonly IDonhangChitietSvc _donhangChitietSvc;
        public CartController(IDonhangSvc donhangSvc, IDonhangChitietSvc donhangChitietSvc)
        {
            _donhangSvc = donhangSvc;
            _donhangChitietSvc = donhangChitietSvc;
        }

        // POST: api/Donhang
        // To protect from overposting attacks, see https://go.microsoft.com/fw;ink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> PostCart(Cart giohang)
        {
            try
            {
                var donhang = new Donhang()
                {
                    TrangthaiDonhang = TrangthaiDonhang.Moidat,
                    KhachhangID = giohang.KhanghangId,
                    Tongtien = giohang.Tongtien,
                    Ngaydat = DateTime.Now,
                    Ghichu = "",
                };
                int donhangID = await _donhangSvc.AddDonhangAsync(donhang);
                donhang.DonhangID = donhangID;

                List<CartItem> dataCart = giohang.ListViewCart;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    DonhangChitiet chitiet = new DonhangChitiet()
                    {
                        DonhangID = donhangID,
                        MonAnID = dataCart[i].MonAn.MonAnID,
                        Soluong = dataCart[i].Quantity,
                        Thanhtien = dataCart[i].MonAn.Gia * dataCart[i].Quantity,
                        Ghichu = "",
                    };
                    _donhangChitietSvc.AddDonhangChitietSvc(chitiet);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
