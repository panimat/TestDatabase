using BL.Services.Interfaces;
using BL.Services.Models;
using DL.Context.Entities;
using DL.Context.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services.Services
{
    public class DataService : IDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Dictionary<string, List<DataPoint>> GetData()
        {
            var dataPointsJson = new List<DataPoint>();
            var dataPointsJsonB = new List<DataPoint>();
            var dataPointsString = new List<DataPoint>();
            var dataPointsEntity = new List<DataPoint>();

            var resultDict = new Dictionary<string, List<DataPoint>>();

            var listData = _unitOfWork.ResultEntities.GetAll().GroupBy(x => x.AmountElements).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var result in listData)
            {
                var resultJson = new List<double>();
                var resultJsonB = new List<double>();
                var resultString = new List<double>();
                var resultEntity = new List<double>();

                foreach (var item in result.Value)
                {
                    resultJson.Add(item.JSONFind);
                    resultJsonB.Add(item.JSONBFind);
                    resultString.Add(item.StringFind);
                    resultEntity.Add(item.EntityFind);
                }

                dataPointsJson.Add(new DataPoint(result.Key, resultJson.Average()));
                dataPointsJsonB.Add(new DataPoint(result.Key, resultJsonB.Average()));
                dataPointsString.Add(new DataPoint(result.Key, resultString.Average()));
                dataPointsEntity.Add(new DataPoint(result.Key, resultEntity.Average()));
            }

            resultDict.Add("dataPointsJson", dataPointsJson.OrderBy(x => x.Label).ToList());
            resultDict.Add("dataPointsJsonB", dataPointsJsonB.OrderBy(x => x.Label).ToList());
            resultDict.Add("dataPointsString", dataPointsString.OrderBy(x => x.Label).ToList());
            resultDict.Add("dataPointsEntity", dataPointsEntity.OrderBy(x => x.Label).ToList());

            return resultDict;
        }
    }
}
