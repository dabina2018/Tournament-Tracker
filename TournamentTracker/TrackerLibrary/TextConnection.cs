using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    class TextConnection : IDataConnection
    {
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;
            return model;
        }
    }
}
