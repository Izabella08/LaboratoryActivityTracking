using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class AssignmentEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime Deadline { get; set; }
        public String AssignmentText { get; set; }
        public LaboratoryEntity Laboratory { get; set; }
    }
}
