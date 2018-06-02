using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleSample
{
    public interface IPartAvailabilityServiceClient: ICommunicationObject, IPartAvailabilityService, IDisposable { }

    public partial class PartAvailabilityServiceClient : IPartAvailabilityServiceClient { }

    public class PartAvailabilityServiceClientFactory
    {
        public virtual IPartAvailabilityServiceClient GetClient()
        {
            return new PartAvailabilityServiceClient();
        }
    }
}
