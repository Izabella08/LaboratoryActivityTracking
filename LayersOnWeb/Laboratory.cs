using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb
{
    public class Laboratory
    {
        public Guid Id { get; set; }
        public int LabNumber { get; set; }
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public String Objectives { get; set; }
        public String Description { get; set; }
    }
}
