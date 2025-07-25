using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Interface;
using WebApiEducation.Domain.Model;
using WebApiEducation.Infrastructure.Persistence;


namespace WebApiEducation.Infrastructure.Repository
{
    public class LogWebApiRepository : ILogWebApiRepository
    {
        private readonly AudisoftEducationContext _context;

        public LogWebApiRepository(AudisoftEducationContext context)=>_context = context;
        

        public async Task<ResponseService> AddLog(LogWebApi log)
        {
            _context.LogWebApi.Add(log);
            await _context.SaveChangesAsync();
            return new ResponseService { Message = "Se ha agregado registro en el log", Success = true };
        }

        public async Task<List<LogWebApi>> GetAll() => await _context.LogWebApi.ToListAsync();

    }
}
