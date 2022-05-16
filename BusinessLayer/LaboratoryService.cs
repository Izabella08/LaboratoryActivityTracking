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
    public class LaboratoryService : ILaboratoryService
    {
        private readonly IRepository repository;

        public LaboratoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddLaboratoryModel(LaboratoryModel laboratory)
        {
            repository.Add(new LaboratoryEntity { LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description });
            repository.SaveChanges();
        }

      
        public List<LaboratoryModel> GetAllLaboratories()
        {
            List<LaboratoryModel> result = new List<LaboratoryModel>();
            foreach (var laboratory in repository.GetAll<LaboratoryEntity>())
            {
                result.Add(new LaboratoryModel { Id = laboratory.Id, LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description });
            }
            return result;
        }


        public bool DeleteLaboratoryModelById(Guid laboratoryId)
        {
            try
            {
                var DataList = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == laboratoryId).ToList();
                foreach (var item in DataList)
                {
                    repository.Delete(item);
                    repository.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateLaboratoryModel(LaboratoryModel laboratory)
        {
            try
            {
                var item = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == laboratory.Id).FirstOrDefault();
                item.LabNumber = laboratory.LabNumber;
                item.Date = laboratory.Date;
                item.Title = laboratory.Title;
                item.Objectives = laboratory.Objectives;
                item.Description = laboratory.Description;
                repository.Update(item);
                repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public LaboratoryModel GetLaboratoryModelById(Guid Id)
        {
            var laboratory = repository.GetById<LaboratoryEntity>(Id);
            return new LaboratoryModel { Id = laboratory.Id, LabNumber = laboratory.LabNumber, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description };
        }
    }
}
