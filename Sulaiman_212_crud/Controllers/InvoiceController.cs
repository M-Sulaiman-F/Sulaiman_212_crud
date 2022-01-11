using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sulaiman_212_crud.Data;
using Sulaiman_212_crud.Models;

namespace Sulaiman_212_crud.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly StoreDB _context;

        public InvoiceController(StoreDB context)
        {
            _context = context;
        }

        // GET: Invoice
        public  IActionResult ViewOrder()
        {
            return View(_context.Orders.ToList());
        }



        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModel);
                 _context.SaveChanges();
                return RedirectToAction("ViewOrder");
            }
            return View(orderModel);
        }


        public IActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = _context.Orders
                .FirstOrDefault(m => m.id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderModel = _context.Orders.Find(id);
            _context.Orders.Remove(orderModel);
            _context.SaveChanges();
            return RedirectToAction("ViewOrder");
        }

        private bool OrderModelExists(int id)
        {
            return _context.Orders.Any(e => e.id == id);
        }
    }
}
