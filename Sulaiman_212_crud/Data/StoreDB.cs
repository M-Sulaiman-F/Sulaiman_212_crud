using Microsoft.EntityFrameworkCore;
using Sulaiman_212_crud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sulaiman_212_crud.Data
{
    public class StoreDB: DbContext
    {
        public StoreDB(DbContextOptions<StoreDB> options):base(options)
        {

        }
        public DbSet<OrderModel> Orders{ get; set; }
    }
}
