using Application.Entities;
using Application.Enum;

namespace Application.Abstract
{
    public abstract class ServiceBase
    {
        public ServiceBase(DataDict dataDict)
        {
            this.Dictionary = dataDict;
        }
        public DataDict Dictionary { get; set;  }
        public abstract Task<ServiceState> StartService();

    }
}
