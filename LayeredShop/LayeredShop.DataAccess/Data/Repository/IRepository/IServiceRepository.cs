﻿using LayeredShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LayeredShop.DataAccess.Data.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        void Update(Service service);
    }
}
