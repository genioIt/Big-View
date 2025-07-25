using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEducation.Domain.Entity
{
    /// <summary>
    /// Estudiantes
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

       public ICollection<Note> Note { get; set; }
    }
}
