namespace PinnacleSample
{
    public class PartInvoiceController
    {
        ICustomerRepository _CustomerRepository;
        IPartInvoiceRepository _PartInvoiceRepository;

        // Dependency Injection only at construction time - avoid strange behavior for subsequent codes
        public PartInvoiceController()
        {
            this._CustomerRepository = new CustomerRepositoryDB();
            this._PartInvoiceRepository = new PartInvoiceRepositoryDB();
        }

        public PartInvoiceController(ICustomerRepository CustomerRepository, IPartInvoiceRepository PartInvoiceRepository)
        {
            this._CustomerRepository = CustomerRepository;
            this._PartInvoiceRepository = PartInvoiceRepository;
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            if (string.IsNullOrEmpty(stockCode))
            {
                return new CreatePartInvoiceResult(false);
            }

            if (quantity <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            Customer _Customer = _CustomerRepository.GetByName(customerName);
            if (_Customer.ID <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            using (PartAvailabilityServiceClient _PartAvailabilityService = new PartAvailabilityServiceClient())
            {
                int _Availability = _PartAvailabilityService.GetAvailability(stockCode);
                if (_Availability <= 0)
                {
                    return new CreatePartInvoiceResult(false);
                }
            }

            PartInvoice _PartInvoice = new PartInvoice
            {
                StockCode = stockCode,
                Quantity = quantity,
                CustomerID = _Customer.ID
            };
            
            _PartInvoiceRepository.Add(_PartInvoice);

            return new CreatePartInvoiceResult(true);
        }
    }
}
