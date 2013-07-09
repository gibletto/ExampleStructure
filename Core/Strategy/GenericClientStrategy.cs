using System;
using Core.Interfaces.Strategy;

namespace Core.Strategy
{
    class GenericClientStrategy : ISomeStrategy
    {
        public void DoCustomerSpecificAlg()
        {
            throw new NotImplementedException();
        }
    }
}
