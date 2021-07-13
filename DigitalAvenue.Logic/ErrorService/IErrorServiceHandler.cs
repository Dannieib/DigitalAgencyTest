using DigitalAvenue.Models;
using System.Threading.Tasks;

namespace DigitalAvenue.Logic
{
    public interface IErrorServiceHandler
    {
        Task<bool> Save(string errorMessage, string stackTrace = null, ErrorTypeEnum errorTypeEnum = ErrorTypeEnum.Exception);
    }
}