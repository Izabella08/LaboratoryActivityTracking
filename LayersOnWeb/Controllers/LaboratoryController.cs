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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService laboratoryService;
        public LaboratoryController(ILaboratoryService laboratoryService)
        {
            this.laboratoryService = laboratoryService;
        }


        [HttpGet("GetAllLaboratories")]
        [Authorize(Roles = "Teacher, Student")]
        public IEnumerable<Laboratory> Get()
        {
            var result = new List<Laboratory>();
            foreach (var laboratory in laboratoryService.GetAllLaboratories())
            {
                result.Add(new Laboratory { Id = laboratory.Id, LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description });
            }
            return result;
        }


        [HttpPost("AddLaboratory")]
        [Authorize(Roles = "Teacher")]
        public void Post(Laboratory laboratory)
        {
            laboratoryService.AddLaboratoryModel(new LaboratoryModel { LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description } );
        }


        [HttpDelete("DeleteLaboratoryById")]
        [Authorize(Roles = "Teacher")]
        public bool DeleteLaboratoryById(Guid laboratoryId)
        {
            try
            {
                laboratoryService.DeleteLaboratoryModelById(laboratoryId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpPut("UpdateLaboratory")]
        [Authorize(Roles = "Teacher")]
        public bool UpdateLaboratory(LaboratoryModel laboratory)
        {
            try
            {
                laboratoryService.UpdateLaboratoryModel(laboratory);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        [HttpGet("GetLaboratoryById")]
        [Authorize(Roles = "Teacher")]
        public Object GetLaboratoryById(Guid Id)
        {
            try
            {
                var data = laboratoryService.GetLaboratoryModelById(Id);
                if (data == null) return NotFound();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
