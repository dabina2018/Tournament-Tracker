using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        //unique identifier
        public int Id { get; set; }
        /// <summary>
        /// Represents one team in teh matchup
        /// </summary>
        // the unique identifer for the team
        public int TeamCompetingId { get; set; }
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score for this particular team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represents the score for the matchup that this team came from as the winner.
        /// </summary>
        // unique identifier for the parent matchup team
        public int ParentMatchupId {get; set;}
        /// <summary>
        /// represents the matchup that this team came from as the winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
      
       
    }
}
