using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface ILaboratoryService
    {
        List<LaboratoryModel> GetAllLaboratories();
        void AddLaboratoryModel(LaboratoryModel laboratory);
        bool DeleteLaboratoryModelById(Guid laboratoryId);
        bool UpdateLaboratoryModel(LaboratoryModel laboratory);
        LaboratoryModel GetLaboratoryModelById(Guid Id);
    }
}
