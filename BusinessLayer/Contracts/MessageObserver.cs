using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class MessageObserver : IGradingObserver
    {
        public void UpdateMessage(GradingModel gradingModel)
        {
            Console.WriteLine("Assignment with Id '{0}' grade status is updated to '{1}'. A message sent to the student.",
                gradingModel.Assignment.Id, gradingModel.Grade);
        }
    }
}
