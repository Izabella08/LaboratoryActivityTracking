using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
        }


        [HttpGet("GetAllAssignments")]
        [Authorize(Roles = "Teacher, Student")]
        public IEnumerable<Assignment> Get()
        {
            var result = new List<Assignment>();
            foreach (var assignment in assignmentService.GetAllAssignments())
            {
                result.Add(new Assignment { Id = assignment.Id, Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = assignment.Laboratory });
            }
            return result;
        }


        [HttpPost("AddAssignment")]
        [Authorize(Roles = "Teacher")]
        //[Auth]
        public void Post(Assignment assignment)
        {
            assignmentService.AddAssignmentModel(new AssignmentModel { Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = assignment.Laboratory });
        }


        [HttpDelete("DeleteAssignment")]
        [Authorize(Roles = "Teacher")]
        public bool DeleteAssignmentById(AssignmentModel assignment)
        {
            try
            {
                assignmentService.DeleteAssignmentModelById(assignment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpPut("UpdateAssignment")]
        [Authorize(Roles = "Teacher")]
        public bool UpdateAssignment(AssignmentModel assignment)
        {
            try
            {
                assignmentService.UpdateAssignmentModel(assignment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpGet("GetAssignmentById")]
        [Authorize(Roles = "Teacher")]
        public Object GetAssignmentById(Guid Id)
        {
            try
            {
                var data = assignmentService.GetAssignmentModelById(Id);
                if (data == null) return NotFound();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpGet("ViewAllAssignmentsForALaboratory")]
        [Authorize(Roles = "Teacher, Student")]
        public IEnumerable<Assignment> ViewAssignmentForALaboratory(Guid laboratoryId)
        {
            var result = new List<Assignment>();
            foreach (var assignment in assignmentService.GetAllAssignmentForALaboratory(laboratoryId))
            {
                if (assignment.Laboratory.Id == laboratoryId)
                {
                    result.Add(new Assignment { Id = assignment.Id, Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = assignment.Laboratory });
                }
            }
            return result;
        }
    }
}
