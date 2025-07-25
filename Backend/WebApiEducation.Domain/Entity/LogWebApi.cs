using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEducation.Domain.Entity
{
    public class LogWebApi
    {
        public int Id { set; get; }
        public string Method { set; get; }
        public string Message { set; get; }
    }
}
