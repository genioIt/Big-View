using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEducation.Domain.Entity
{
    public class Note
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int idTeacher { set; get; }
        public int idStudent { set; get; }
        public Double Value { set; get; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
