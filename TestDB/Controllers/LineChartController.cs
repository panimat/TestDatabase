using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Services.Interfaces;
using BL.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestDB.Controllers
{
    public class LineChartController : Controller
    {
        private readonly IDataService _dataService;
        public LineChartController(IDataService dataService)
        {
            _dataService = dataService;
        }
        public IActionResult Index()
        {
            
            var data = _dataService.GetData();

            
            ViewBag.DataPointsJson = JsonConvert.SerializeObject(data["dataPointsJson"]);
            ViewBag.DataPointsJsonB = JsonConvert.SerializeObject(data["dataPointsJsonB"]);
            ViewBag.DataPointsString = JsonConvert.SerializeObject(data["dataPointsString"]);
            ViewBag.DataPointsEntity = JsonConvert.SerializeObject(data["dataPointsEntity"]);

            return View();
            
            
            /*
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("Jan", 72));
            dataPoints1.Add(new DataPoint("Feb", 67));
            dataPoints1.Add(new DataPoint("Mar", 55));
            dataPoints1.Add(new DataPoint("Apr", 42));
            dataPoints1.Add(new DataPoint("May", 40));
            dataPoints1.Add(new DataPoint("Jun", 35));

            dataPoints2.Add(new DataPoint("Jan", 48));
            dataPoints2.Add(new DataPoint("Feb", 56));
            dataPoints2.Add(new DataPoint("Mar", 50));
            dataPoints2.Add(new DataPoint("Apr", 47));
            dataPoints2.Add(new DataPoint("May", 65));
            dataPoints2.Add(new DataPoint("Jun", 69));

            dataPoints3.Add(new DataPoint("Jan", 38));
            dataPoints3.Add(new DataPoint("Feb", 46));
            dataPoints3.Add(new DataPoint("Mar", 55));
            dataPoints3.Add(new DataPoint("Apr", 70));
            dataPoints3.Add(new DataPoint("May", 77));
            dataPoints3.Add(new DataPoint("Jun", 91));

            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);

            return View();
            */
            
        }
    }
}