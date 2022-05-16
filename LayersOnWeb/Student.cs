using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb
{
    public class Student
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public int Group { get; set; }
        public String Hobby { get; set; }
        public int FinalGrade { get; set; }
        public Boolean Passed { get; set; }

    }
}
