using Data.EF;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TGClothes.Areas.Admin.Controllers
{
    public class ColorController : BaseController
    {
        private readonly IColorService _colorService;
        // GET: Admin/Color
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: Admin/Color
        public ActionResult Index()
        {
            var colors = _colorService.GetAll();
            return View(colors);
        }

        // GET: Admin/Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Color/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                long id = _colorService.Insert(color);
                if(id > 0)
                {
                    SetAlert("Thêm mới color thành công", "success");
                    return RedirectToAction("Index", "Color");

                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới color không thành công.");
                }
            }
            return View("Index");
        }

        // GET: Admin/Color/Edit/5
        public ActionResult Edit(long id)
        {
            var color = _colorService.GetColorById(id);
            return View(color);
        }

        // POST: Admin/Color/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Color color)
        {
            if (ModelState.IsValid)
            {
               
                var result = _colorService.Update(color);
                if (result) 
                {
                    SetAlert("Cập nhật màu thành công", "success");
                    return RedirectToAction("Index", "Color");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật màu không thành công.");
                }
                
            }
            return View("Index");

        }

        // GET: Admin/Color/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _colorService.Delete(id);         
            return RedirectToAction("Index");
        }

        //// POST: Admin/Color/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    _colorService.Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}