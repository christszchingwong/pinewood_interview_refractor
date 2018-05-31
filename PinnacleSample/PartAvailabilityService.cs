namespace PinnacleSample
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "App.IPartSupplierService")]
    public interface IPartAvailabilityService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPartAvailabilityService/GetAvailability", ReplyAction = "http://tempuri.org/IPartSupplierService/GetAvailabilityResponse")]
        int GetAvailability(string StockCode);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPartAvailabilityServiceChannel : PinnacleSample.IPartAvailabilityService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PartAvailabilityServiceClient : System.ServiceModel.ClientBase<PinnacleSample.IPartAvailabilityService>, PinnacleSample.IPartAvailabilityService
    {

        public PartAvailabilityServiceClient()
        {
        }

        public PartAvailabilityServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public PartAvailabilityServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public PartAvailabilityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public PartAvailabilityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public int GetAvailability(string stockCode)
        {
            return base.Channel.GetAvailability(stockCode);
        }
    }
}
