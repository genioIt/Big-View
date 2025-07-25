using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEducation.Domain.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Teacher
    {
      public int Id { get; set; }
      public string Names { get; set; }

        public ICollection<Note> Note { get; set; }
    }
}
