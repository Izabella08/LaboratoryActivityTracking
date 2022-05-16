using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradingController : ControllerBase
    {
        private readonly IGradingService gradingService;
        public GradingController(IGradingService gradingService)
        {
            this.gradingService = gradingService;
        }


        [HttpGet("GetAllGradingModels")]
        [Authorize(Roles = "Teacher")]
        public IEnumerable<Grading> Get()
        {
            var result = new List<Grading>();
            foreach (var grading in gradingService.GetAllGradingModels())
            {
                result.Add(new Grading { Id = grading.Id, Assignment = grading.Assignment, Student = grading.Student, assignmentSubmission = grading.assignmentSubmission, assignmentComments = grading.assignmentComments, Grade = grading.Grade });
            }
            return result;
        }


        [HttpPost("CreateAssignmentSubmission")]
        [Authorize(Roles = "Student")]
        //[Auth]
        public String Post(Grading grading)
        {
            if (grading.Assignment.Id != null && grading.Student.Id != null)
            {
                gradingService.CreateAssignmentSubmission(new GradingModel { Assignment = grading.Assignment, Student = grading.Student, assignmentSubmission = grading.assignmentSubmission, assignmentComments = grading.assignmentComments });
                return "Assignment submitted successfully!";
            }
            else
            {
                return "Something went wrong!";
            }
        }


        [HttpPut("GradeSubmittedAssignment")]
        [Authorize(Roles = "Teacher")]
        public String GradeSubmittedAssignment(GradingModel grading)
        {
            try
            {
                Console.WriteLine("Attaching Observers...");

                var messageObserver = new MessageObserver();

                gradingService.Attach(messageObserver);

                Console.WriteLine("Updating Assignment Status...");

                gradingService.GradeSubmittedAssignment(grading);

                return "Assignment graded successfully!";
            }
            catch (Exception)
            {
                return "Something went wrong";
            }
        }

        
        [HttpPut("ComputeFinalGrade")]
        [Authorize(Roles = "Teacher")]
        public bool ComputeFinalGrade(Guid studentId)
        {
            try
            {
                gradingService.ComputeFinalGrade(studentId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
