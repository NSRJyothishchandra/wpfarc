using Microsoft.EntityFrameworkCore;

namespace ActiveOutageApi.Models
{
    public class StorePro
    {
        public int ActiveOutages { get; set; }
        public long TotalAffectedCustomers { get; set; }
        public long TotalCustomersServed { get; set; }
    }

}
