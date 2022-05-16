using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IGradingService : IGradingNotifier
    {
        void CreateAssignmentSubmission(GradingModel grading);
        List<GradingModel> GetAllGradingModels();
        bool GradeSubmittedAssignment(GradingModel grading);
        void ComputeFinalGrade(Guid studentId);
    }
}
