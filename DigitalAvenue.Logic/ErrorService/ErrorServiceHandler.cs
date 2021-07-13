using DigitalAvenue.Models;
using DigitalAvenue.Repository.ErrorRepo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Logic
{
    public class ErrorServiceHandler : IErrorServiceHandler
    {

        readonly IErrorLoggerRepo _errorLoggerRepo;
        private string m_exePath = string.Empty;
        public ErrorServiceHandler(IErrorLoggerRepo errorLoggerRepo)
        {
            _errorLoggerRepo = errorLoggerRepo;
        }

        public async Task<bool> Save(string errorMessage, string stackTrace = null, ErrorTypeEnum errorTypeEnum = ErrorTypeEnum.Exception)
        {
            try
            {
                LogWrite(errorMessage);
                var res = await _errorLoggerRepo.LognewError(new ErrorLogModel { ErrorMessage = errorMessage, ErrorStackTrace = stackTrace, ErrorType = errorTypeEnum.ToString() });

                if (res >0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                await Save(ex.Message, ex.StackTrace, ErrorTypeEnum.Exception);
                LogWrite(ex.Message);
                throw ex;
            }
        }
         
        private void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "Exceptionlog.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
