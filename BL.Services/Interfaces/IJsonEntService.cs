using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IJsonEntService
    {
        int Count();
        void FillTable(int amountValue);
        int GetLastIndex();
        void Dispose();
    }
}
