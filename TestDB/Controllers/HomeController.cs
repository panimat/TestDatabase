using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestDB.Models;
using BL.Services.Interfaces;

namespace TestDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJsonEntService _entService;
        public HomeController(IJsonEntService entService)
        {
            _entService = entService;
        }

        public IActionResult Index()
        {
            return View(new JsonEntityViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult MakeData()
        {
            _entService.FillTable();
            return View("OkPage");
        }

        [HttpPost]
        public IActionResult FindBy(string val)
        {
            if (!String.IsNullOrEmpty(val))
            {
                var values = new List<string>();

                double temp1, temp2;

                for (int i = 0; i < 50; i++)
                {
                    temp1 = Math.Round(_entService.GetJsonVal(val), 5);

                    temp2 = Math.Round(_entService.GetStringVal(val), 5);

                    values.Add($"Json value: " + temp1 + " string value: " + temp2);
                }

                return View("Index", new JsonEntityViewModel
                {
                    Val = values,
                    Change = true
                }) ;;
            }
            else return View("Index", new JsonEntityViewModel());
        }
    }
}
