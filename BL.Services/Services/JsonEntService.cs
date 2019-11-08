using System;
using System.Collections.Generic;
using System.Text;
using BL.Services.Interfaces;
using DL.Context.Interfaces;
using DL.Context.Entities;
using System.Linq;
using System.Diagnostics;

namespace BL.Services.Services
{
    public class JsonEntService : IJsonEntService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JsonEntService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void FillTable()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            for (int i = 0; i < 10000; i++)
            {
                StringBuilder result = new StringBuilder(6);
                for (int j = 0; j < 6; j++)
                    result.Append(chars[random.Next(chars.Length)]);
                   
                _unitOfWork.JsonEntities.Create(new JsonEntity {
                    TestJsonColumn = "{ " + '\u0022' + result.ToString() + '\u0022' + " : " + '\u0022' + result.ToString() + '\u0022' + " }",
                    StringField = result.ToString(),
                    JsonValField = new JsonField
                    {
                        Key = result.ToString(),
                        Value = result.ToString()
                    }
                });
            }
            _unitOfWork.Save();
        }

        public double GetJsonVal(string findVal)
        {
            return _unitOfWork.JsonEntities.FindByJson(findVal);
        }

        public double GetStringVal(string findVal)
        {
            return _unitOfWork.JsonEntities.FindByString(findVal);
        }

        public int Count()
        {
            return _unitOfWork.JsonEntities.Count();
        }
    }
}
