using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class GradingEntity
    {
        public Guid Id { get; set; }
        public AssignmentEntity Assignment { get; set; }
        public StudentEntity Student { get; set; }
        public String assignmentSubmission { get; set; }
        public String assignmentComments { get; set; }
        public Double Grade { get; set; }
    }
}
