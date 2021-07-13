using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Models
{
    public class ErrorLogModel
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public string ErrorStackTrace { get; set; }
        public DateTime DateTimeCatched { get; set; }
    }
}
