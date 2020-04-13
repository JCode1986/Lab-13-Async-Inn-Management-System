using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Interfaces;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IHotelManager _hotel;

        public HomeController(IHotelManager hotel)
        {
            _hotel = hotel;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _hotel.GetAllHotels();
            return View(result);
        }
/*        public IActionResult Index()
        {
            return View();
        }*/
    }
}