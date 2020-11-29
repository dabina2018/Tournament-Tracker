using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);
    }
}
