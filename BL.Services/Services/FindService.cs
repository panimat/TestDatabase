using System;
using System.Collections.Generic;
using System.Text;
using BL.Services.Interfaces;
using DL.Context.Interfaces;
using BL.Services.Models;
using DL.Context.Entities;
using System.Linq;

namespace BL.Services.Services
{
    public class FindService : IFindService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJsonEntService _jsonEntService;
        public FindService(IUnitOfWork unitOfWork, IJsonEntService entService)
        {
            _unitOfWork = unitOfWork;
            _jsonEntService = entService;
        }
        
        public void FindValues(int amount)
        {
            for (int i = 1; i < 30; i++)
            {
                var localAmount = amount * i;
                _jsonEntService.FillTable(localAmount);

                var values = FindRandomValue(GetMinVal(localAmount), GetMinVal(localAmount) + localAmount);

                foreach (var item in values)
                {
                    var result = new Result();

                    item.Remove(0, 1);

                    result.AmountElements = localAmount;
                    result.JSONFind = Math.Round(Enumerable.Average(GetJsonVal(item)), 5);
                    result.JSONBFind = Math.Round(Enumerable.Average(GetJsonB(item)), 5);
                    result.StringFind = Math.Round(Enumerable.Average(GetStringVal(item)), 5);
                    result.EntityFind = Math.Round(Enumerable.Average(GetJsonValEnt(item)), 5);

                    _unitOfWork.ResultEntities.Create(result);
                    _unitOfWork.Save();
                }
            }
        }

        private IEnumerable<string> FindRandomValue(int minVal, int maxVal)
        {
            var arr = new List<string>();

            try
            {
                Random rand = new Random();
                for (int i = 0; i < 5; i++)
                    arr.Add(_unitOfWork.JsonEntities.Get(rand.Next(minVal, maxVal)).StringField);
            }
            catch (Exception ex)
            {

            }
            return arr;
        }

        private IEnumerable<double> GetJsonVal(string findVal)
        {
            return _unitOfWork.JsonEntities.FindByJson(findVal);
        }

        private IEnumerable<double> GetStringVal(string findVal)
        {
            return _unitOfWork.JsonEntities.FindByString(findVal);
        }

        private IEnumerable<double> GetJsonValEnt(string findVal)
        {
            return _unitOfWork.JsonEntities.FindByJsonEntity(findVal);
        }

        private IEnumerable<double> GetJsonB(string findVal)
        {
            return _unitOfWork.JsonEntities.FindByJsonB(findVal);
        }

        private int GetMinVal(int amount)
        {
            if (_unitOfWork.JsonEntities.GetLastIndex() - amount >= 0)
                return _unitOfWork.JsonEntities.GetLastIndex() - amount;
            else return 0;
        }
    }
}
