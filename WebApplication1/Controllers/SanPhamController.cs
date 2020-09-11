using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class SanPhamController : ApiController
    {
        //Lấy ds sản phẩm
        [Route("api/SANPHAM")]
        [HttpGet]
        public List<SANPHAM> GET()
        {
           SanPhamDBDataContext db = new SanPhamDBDataContext();
            return db.SANPHAMs.ToList();
        }

        //Lấy ds sản phẩm theo id sản phẩm
        [HttpGet]
        public SANPHAM GetPro(string id)
        {
            SanPhamDBDataContext db = new SanPhamDBDataContext();
            return db.SANPHAMs.FirstOrDefault(x => x.MASP == id);
        }

        [HttpPost]
        public bool InsertNewProduct(string name, float cost,string pic, string direc)
        {
            try
            {
                SanPhamDBDataContext db = new SanPhamDBDataContext();
                SANPHAM sp = new SANPHAM();
                sp.TENSP = name;
                sp.DONGIA = cost;
                sp.HINHANH = pic;
                sp.CHITIET = direc;
                db.SANPHAMs.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
