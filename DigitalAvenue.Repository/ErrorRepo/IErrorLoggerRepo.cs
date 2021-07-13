using DigitalAvenue.Models;
using System.Threading.Tasks;

namespace DigitalAvenue.Repository.ErrorRepo
{
    public interface IErrorLoggerRepo
    {
        Task<int> LognewError(ErrorLogModel model);
    }
}