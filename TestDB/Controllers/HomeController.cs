using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestDB.Models;
using BL.Services.Interfaces;
using DL.Context.Interfaces;
using System.Linq;

namespace TestDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFindService _findService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJsonEntService _jsonEntService;
        public HomeController(IFindService findService, IUnitOfWork unitOfWork, IJsonEntService jsonEntService)
        {
            _findService = findService;
            _unitOfWork = unitOfWork;
            _jsonEntService = jsonEntService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(GetResult());
        }

        [HttpGet]
        public IActionResult FindBy(int amount)
        {
            _findService.FindValues(amount);

            return View("Index", GetResult());
        }

        [HttpGet]
        public IActionResult ClearResult()
        {
            _jsonEntService.ClearResult();
            return View("Index", GetResult());
        }

        [HttpGet]
        public IActionResult ClearDB()
        {
            _jsonEntService.ClearDB();
            return View("Index", GetResult());
        }

        private ResultViewModel GetResult()
        {
            var viewResult = new ResultViewModel() { Results = new List<Result>(), Change = false };

            var allRes = _unitOfWork.ResultEntities.GetAll();
            
            if (allRes == null)
                return new ResultViewModel();

            foreach (var item in allRes)
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

            viewResult.Results.OrderBy(x => x.AmountElements);
            viewResult.Change = true;

            return viewResult;
        }
    }
}
