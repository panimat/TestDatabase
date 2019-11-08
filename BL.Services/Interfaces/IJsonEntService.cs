using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IJsonEntService
    {
        double GetStringVal(string _findVal);
        double GetJsonVal(string _findVal);
        int Count();
        void FillTable();
        void Dispose();
    }
}
