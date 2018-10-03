using System;
using System.Collections.Generic;
using System.Text;

namespace greenPower.Core.Repository
{
    interface IDataRepository : IRepository
    {
        bool DataExists(uint address);
        Data[] GetAllData();
        Data GetOneData(uint address);
        void WriteOneData(uint address);
    }
}
