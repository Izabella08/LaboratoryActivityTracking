using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class GradingModel
    {
        public Guid Id { get; set; }
        public AssignmentModel Assignment { get; set; }
        public StudentModel Student { get; set; }
        public String assignmentSubmission { get; set; }
        public String assignmentComments { get; set; }
        public Double Grade { get; set; }

    }
}
