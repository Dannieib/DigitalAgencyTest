using System.Data;

namespace DigitalAvenue.Repository.StorageUtil
{
    public interface IStorage
    {
        IDbConnection Connection { get; }
    }
}