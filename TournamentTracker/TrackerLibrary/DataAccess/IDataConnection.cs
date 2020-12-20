using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);
    }
}
