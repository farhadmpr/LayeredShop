using LayeredShop.DataAccess.Data.Repository.IRepository;
using LayeredShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayeredShop.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Categories.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var cat = _db.Categories.FirstOrDefault(s => s.Id == category.Id);

            cat.Name = category.Name;
            cat.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
