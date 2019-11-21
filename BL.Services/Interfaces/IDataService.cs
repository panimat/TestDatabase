using BL.Services.Models;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface IDataService
    {
        Dictionary<string, List<DataPoint>> GetData();
    }
}
