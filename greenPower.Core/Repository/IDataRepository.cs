using greenPower.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace greenPower.Core.Repository
{
    interface IDataRepository : IRepository
    {
        Task WriteOneData(uint address);
        Task<bool> DataExists(uint address);
        Task<Data[]> GetAllData();
        Task<Data> GetData();
        Task<Data> GetOneData(uint address);
    }
}
