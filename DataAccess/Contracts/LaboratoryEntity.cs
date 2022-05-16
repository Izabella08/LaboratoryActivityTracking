using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class LaboratoryEntity
    {
        public Guid Id { get; set; }
        public int LabNumber { get; set; }
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public String Objectives { get; set; }
        public String Description { get; set; }
    }
}
