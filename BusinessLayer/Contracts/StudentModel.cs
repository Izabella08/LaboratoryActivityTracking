using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class StudentModel
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
