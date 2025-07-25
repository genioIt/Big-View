using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEducation.Domain.Entity
{
    public class NoteDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int idTeacher { set; get; }
        public int idStudent { set; get; }
        public Double value { set; get; }
    }
}
