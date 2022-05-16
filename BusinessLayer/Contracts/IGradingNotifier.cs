using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IGradingNotifier
    {
        void Attach(IGradingObserver observer);

        void Detach(IGradingObserver observer);

        void Notify(GradingModel gradingModel);
    }
}
