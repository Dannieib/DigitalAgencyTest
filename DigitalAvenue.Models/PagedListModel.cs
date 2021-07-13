using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Models
{
    public class PagedListModel<T>
    {
        public IList<T> List { get; set; }
        public int FilteredCount { get; set; }
        public int TotalCount { get; set; }
    }
}
