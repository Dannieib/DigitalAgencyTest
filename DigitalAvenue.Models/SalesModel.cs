using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Models
{
    public class SalesModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public int productId { get; set; }
        public int Quantity { get; set; }
    }
}
