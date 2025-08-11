using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface IChallengingDom
    {
        void DoFirstOperation();
        void DoSecondOperation();
        void EditRow(int rownum);
        void DeleteRow(int rownum);

       // List<ChallengingDomEntry> GetEntries();
    }
}
