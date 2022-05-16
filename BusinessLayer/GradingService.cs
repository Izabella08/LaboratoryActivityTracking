using BusinessLayer.Contracts;
using DataAccess;
using DataAccess.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GradingService : IGradingService
    {
        private readonly IRepository repository;
        public List<IGradingObserver> Observers = new List<IGradingObserver>();

        public GradingService(IRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ComputeFinalGrade(Guid studentId)
        {
            Double averageOfAllGrades = 0;
            Double sumOfAllGrades = 0;
            int nrOfGrades = 0;
            bool verifyPassedCondition = false;
            List<GradingModel> result = new List<GradingModel>();
            var student = repository.GetAll<StudentEntity>().Where(x => x.Id == studentId).FirstOrDefault();
            foreach (var grading in repository.GetAll<GradingEntity>())
            {
                if (grading.Student.Id == studentId && grading.assignmentSubmission != "string" && grading.Grade > 0)
                {
                    var gradeRule = Configuration.GetSection("magicStrings:gradeRule").Value;
                    if (grading.Grade > int.Parse(gradeRule))
                    {
                        verifyPassedCondition = true;
                        sumOfAllGrades += grading.Grade;
                        nrOfGrades++;
                    }
                    else
                    {
                        student.Passed = false;
                        student.FinalGrade = 4;
                        break;
                    }
                }
            }
            if (verifyPassedCondition == true)
            {
                averageOfAllGrades = sumOfAllGrades / nrOfGrades;
                var averageRule = Configuration.GetSection("magicStrings:averageRule").Value;
                if (averageOfAllGrades > int.Parse(averageRule))
                {
                    student.Passed = true;
                    student.FinalGrade = (int)averageOfAllGrades;
                }
                else
                {
                    student.Passed = false;
                    student.FinalGrade = 4;
                }
            }
            repository.SaveChanges();
        }


        public void CreateAssignmentSubmission(GradingModel grading)
        {
            AssignmentEntity assignmentEntity = repository.GetById<AssignmentEntity>(grading.Assignment.Id);
            StudentEntity studentEntity = repository.GetById<StudentEntity>(grading.Student.Id);
            repository.Add(new GradingEntity { Assignment = assignmentEntity, Student = studentEntity, assignmentSubmission = grading.assignmentSubmission, assignmentComments = grading.assignmentComments });
            repository.SaveChanges();
        }


        public List<GradingModel> GetAllGradingModels()
        {
            List<GradingModel> result = new List<GradingModel>();
            foreach (var model in repository.GetAll<GradingEntity>())
            {
                var assignment = repository.GetAll<AssignmentEntity>().Where(x => x.Id == model.Assignment.Id).FirstOrDefault();
                AssignmentModel assignmentModel = new AssignmentModel { Id = assignment.Id, Name = assignment.Name, Deadline = assignment.Deadline, AssignmentText = assignment.AssignmentText };
                var student = repository.GetAll<StudentEntity>().Where(x => x.Id == model.Student.Id).FirstOrDefault();
                StudentModel studentModel = new StudentModel { Id = student.Id, Email = student.Email, Name = student.Name, Group = student.Group, Hobby = student.Hobby, FinalGrade = student.FinalGrade, Passed = student.Passed };
                result.Add(new GradingModel { Id = model.Id, Assignment = assignmentModel, Student = studentModel, assignmentSubmission = model.assignmentSubmission, assignmentComments = model.assignmentComments, Grade = model.Grade });
            }
            return result;
        }


        public bool GradeSubmittedAssignment(GradingModel grading)
        {
            try
            {
                var item = repository.GetAll<GradingEntity>().Where(x => x.Id == grading.Id).FirstOrDefault();
                item.Grade = grading.Grade;
                repository.Update(item);
                repository.SaveChanges();
                Notify(grading);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void Attach(IGradingObserver observer)
        {
            Observers.Add(observer);
        }


        public void Detach(IGradingObserver observer)
        {
            Observers.Add(observer);
        }


        public void Notify(GradingModel gradingModel)
        {
            foreach (var observer in Observers)
            {
                observer.UpdateMessage(gradingModel);
            }
        }
    }
}
