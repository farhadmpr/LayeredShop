using LayeredShop.DataAccess.Data.Repository.IRepository;
using LayeredShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayeredShop.DataAccess.Data.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Service service)
        {
            var s = _db.Services.FirstOrDefault(s => s.Id == service.Id);

            s.Name = service.Name;
            s.CategoryId = service.CategoryId;
            s.ImageUrl = service.ImageUrl;
            s.LongDesc = service.LongDesc;
            s.Price = service.Price;

            _db.SaveChanges();
        }
    }
}
