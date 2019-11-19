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

        public void FillTable(int amountValue)
        {
            try
            {
                _unitOfWork.ResultEntities.DeleteAllData();
                _unitOfWork.JsonEntities.DeleteAllData();
                _unitOfWork.Save();

                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random random = new Random();

                for (int i = 0; i < amountValue; i++)
                {
                    StringBuilder result = new StringBuilder(10);
                    for (int j = 0; j < 10; j++)
                        result.Append(chars[random.Next(chars.Length)]);

                    _unitOfWork.JsonEntities.Create(new JsonEntity
                    {
                        TestJsonColumn = new JsonField
                        {
                            Key = result.ToString(),
                            Value = result.ToString()
                        },
                        StringField = result.ToString(),
                        JsonValField = new JsonField
                        {
                            Key = result.ToString(),
                            Value = result.ToString()
                        },
                        JsonVal = new JsonField
                        {
                            Key = result.ToString(),
                            Value = result.ToString()
                        }
                    });
                }
                _unitOfWork.Save();
            }
            catch(Exception ex)
            {

            }
        }
        public int Count()
        {
            return _unitOfWork.JsonEntities.Count();
        }

        public int GetLastIndex()
        {
            return _unitOfWork.JsonEntities.GetAll().OrderByDescending(x => x.Id).First().Id;
        }
    }
}
