using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Domain.Interface
{
    public interface ILogWebApiRepository
    {
        Task<ResponseService> AddLog(LogWebApi log);
        Task<List<LogWebApi>> GetAll();
    }
}
