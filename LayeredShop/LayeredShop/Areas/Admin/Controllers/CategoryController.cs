using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayeredShop.DataAccess.Data.Repository.IRepository;
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
    }
}
