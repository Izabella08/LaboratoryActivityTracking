using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IAssignmentService 
    {
        List<AssignmentModel> GetAllAssignments();
        void AddAssignmentModel(AssignmentModel assignment);
        bool DeleteAssignmentModelById(AssignmentModel assignment);
        bool UpdateAssignmentModel(AssignmentModel assignment);
        AssignmentModel GetAssignmentModelById(Guid Id);
        List<AssignmentModel> GetAllAssignmentForALaboratory(Guid laboratoryId);
    }
}
