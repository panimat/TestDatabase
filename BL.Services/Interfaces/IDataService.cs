using BL.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IDataService
    {
        List<DataPoint> GetData();
    }
}
