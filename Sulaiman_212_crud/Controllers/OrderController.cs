using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulaiman_212_crud.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Invoice/ViewOrder/");
        }
    }
}
