using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IStudentService
    {
        List<StudentModel> GetAllStudents();
        void AddStudentModel(StudentModel student);
        bool DeleteStudentModelById(Guid studentId);
        bool UpdateStudentModel(StudentModel student);
        StudentModel GetStudentModelById(Guid Id);
    }
}
