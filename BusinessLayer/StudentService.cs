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
    public class StudentService : IStudentService
    {
        private readonly IRepository repository;

        public StudentService(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddStudentModel(StudentModel student)
        {
            repository.Add(new StudentEntity { Email = student.Email, Name = student.Name, Group = student.Group, Hobby = student.Hobby});
            repository.SaveChanges();
        }


        public List<StudentModel> GetAllStudents()
        {
         
            List<StudentModel> result = new List<StudentModel>();
            foreach(var student in repository.GetAll<StudentEntity>())
            {
                result.Add(new StudentModel { Id = student.Id, Email = student.Email, Name = student.Name, Group = student.Group, Hobby = student.Hobby, FinalGrade = student.FinalGrade, Passed = student.Passed });
            }
            return result;
        }


        public bool DeleteStudentModelById(Guid studentId)
        {
            try
            {
                var result = repository.GetAll<StudentEntity>().Where(x => x.Id == studentId).ToList();
                foreach(var student in result)
                {
                    repository.Delete(student);
                    repository.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public StudentModel GetStudentModelById(Guid Id)
        {
            var student = repository.GetById<StudentEntity>(Id);
            return new StudentModel { Id = student.Id, Email = student.Email, Name = student.Name, Group = student.Group, Hobby = student.Hobby, FinalGrade = student.FinalGrade, Passed = student.Passed };
        }


        public bool UpdateStudentModel(StudentModel student)
        {
            try
            {
                var item = repository.GetAll<StudentEntity>().Where(x => x.Id == student.Id).FirstOrDefault();
                item.Email = student.Email;
                item.Name = student.Name;
                item.Group = student.Group;
                item.Hobby = student.Hobby;
                repository.Update(item);
                repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
