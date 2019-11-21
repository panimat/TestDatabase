using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestDB.Models;
using BL.Services.Interfaces;
using DL.Context.Interfaces;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace TestDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFindService _findService;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IFindService findService, IUnitOfWork unitOfWork)
        {
            _findService = findService;
            _unitOfWork = unitOfWork;
            var viewResult = new ResultViewModel() { Results = new List<Result>(), Change = false };
        }

        // GET: Home
        public ActionResult Index()
        {


            return View(new ResultViewModel());
        }

        [HttpGet]
        public IActionResult FindBy(int amount)
        {
            _findService.FindValues(amount);

            var viewResult = new ResultViewModel() { Results = new List<Result>(), Change = false };

            foreach (var item in _unitOfWork.ResultEntities.GetAll())
            {
                var result = new Result()
                {
                    AmountElements = item.AmountElements,
                    EntityFind = item.EntityFind,
                    JSONBFind = item.JSONBFind,
                    JSONFind = item.JSONFind,
                    StringFind = item.StringFind
                };

                viewResult.Results.Add(result);
            }

            viewResult.Change = true;

            return View("Index", viewResult);
        }
        
    }
}
