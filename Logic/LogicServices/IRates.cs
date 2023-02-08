using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.LogicServices
{
    public interface IRates
    {
        public Task<string> GetExchangeRateAsync();
    }
}
