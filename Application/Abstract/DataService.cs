using Application.Entities;
using Application.Enum;

namespace Application.Abstract
{
    public abstract class DataService : ServiceBase
    {
        protected DataService(DataDict dataDict) : base(dataDict)
        {
            this.Dictionary = dataDict;
        }

        public override Task<ServiceState> StartService()
        {
            return Process();
        }

        protected abstract Task<ServiceState> Process();
        
    }
}
