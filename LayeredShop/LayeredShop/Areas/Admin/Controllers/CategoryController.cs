using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayeredShop.DataAccess.Data.Repository.IRepository;
using LayeredShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayeredShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Insert(int? id)
        {
            Category category = new Category();

            if (id == null)
            {
                return View(category);
            }

            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.Get(id);
            if (category == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while deleting"
                });
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            return Json(new
            {
                success = true,
                message = "Deleted successful"
            });
        }
        #endregion
    }
}
