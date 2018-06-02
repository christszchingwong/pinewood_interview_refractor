using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PinnacleSample
{
    public interface IPartInvoiceRepository
    {
        void Add(PartInvoice invoice);
    }
}
