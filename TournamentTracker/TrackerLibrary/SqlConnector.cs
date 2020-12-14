using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        //TODO - Make the CreatePrize method save to the DB
        /// <summary>
        /// saves a new prize to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns>the prize info, including the unique id</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;
            return model;
        }
    }
}
