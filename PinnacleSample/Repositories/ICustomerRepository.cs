using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PinnacleSample
{
    public interface ICustomerRepository
    {
        Customer GetByName(string name);
    }
}
