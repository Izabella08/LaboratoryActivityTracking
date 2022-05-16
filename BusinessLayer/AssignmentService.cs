using BusinessLayer.Contracts;
using DataAccess;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository repository;

        public AssignmentService(IRepository repository)
        {
            this.repository = repository;
        }


        public void AddAssignmentModel(AssignmentModel assignment)
        {
            LaboratoryEntity laboratory = repository.GetById<LaboratoryEntity>(assignment.Laboratory.Id);
            repository.Add(new AssignmentEntity { Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = laboratory});
            repository.SaveChanges();
        }
      

        public List<AssignmentModel> GetAllAssignments()
        {
            List<AssignmentModel> result = new List<AssignmentModel>();
            foreach(var assignment in repository.GetAll<AssignmentEntity>())
            {
                var laboratory = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == assignment.Laboratory.Id).FirstOrDefault();
                LaboratoryModel laboratoryModel = new LaboratoryModel { Id = laboratory.Id, LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description };
                result.Add(new AssignmentModel { Id = assignment.Id, Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = laboratoryModel});
            }
            return result;
        }


        public bool DeleteAssignmentModelById(AssignmentModel assignment)
        {
            try
            {
                var list = repository.GetAll<AssignmentEntity>().Where(x => x.Id == assignment.Id).ToList();
                foreach(var item in list)
                {
                    repository.Delete<AssignmentEntity>(item);
                    repository.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateAssignmentModel(AssignmentModel assignment)
        {
            try
            {
                var item = repository.GetAll<AssignmentEntity>().Where(x => x.Id == assignment.Id).FirstOrDefault();
                item.Name = assignment.Name;
                item.Deadline = assignment.Deadline;
                item.AssignmentText = assignment.AssignmentText;
                repository.Update(item);
                repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public AssignmentModel GetAssignmentModelById(Guid Id)
        {
            var assignment = repository.GetById<AssignmentEntity>(Id);
            var laboratory = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == assignment.Laboratory.Id).FirstOrDefault();
            LaboratoryModel laboratoryModel = new LaboratoryModel { Id = laboratory.Id, LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description };
            return new AssignmentModel { Id = assignment.Id, Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = laboratoryModel };
        }
        

        public List<AssignmentModel> GetAllAssignmentForALaboratory(Guid laboratoryId)
        {
            List<AssignmentModel> result = new List<AssignmentModel>();
            var laboratory = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == laboratoryId).FirstOrDefault();
            foreach(var assignment in repository.GetAll<AssignmentEntity>())
            {
                LaboratoryModel laboratoryModel = new LaboratoryModel { Id = laboratory.Id, LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description };
                if(assignment.Laboratory.Id == laboratoryId)
                {
                    result.Add(new AssignmentModel { Id = assignment.Id, Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText, Laboratory = laboratoryModel });
                }
            }
            return result;
        }

    }
}
