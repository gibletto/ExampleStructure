using Core.Interfaces.Services;
using Core.Interfaces.Strategy;
using NHibernate;

namespace Core.Services
{
    //Services can have any references they want, and the logic is not tied to a specific domain model either
    //It might be an aggregation of a nunber of dependencies.
    public class SomeService : ISomeService
    {
        private readonly ISession _session;
        private readonly ISomeStrategy _someStategy;

        public SomeService(ISession session, ISomeStrategy someStategy)
        {
            _session = session;
            _someStategy = someStategy;
        }

        public void SomeNonDomainSpecificMethod()
        {
            //get stuff with ISession, process with injected strategy.
            throw new System.NotImplementedException();
        }
    }
}
