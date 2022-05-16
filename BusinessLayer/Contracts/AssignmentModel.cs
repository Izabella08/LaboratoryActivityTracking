using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class AssignmentModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime Deadline { get; set; }
        public String AssignmentText { get; set; }
        public LaboratoryModel Laboratory { get; set; }
    }
}
