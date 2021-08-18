using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var castDetails = await _castService.GetCastDetails(id);
            return View(castDetails);
        }
    }
}
