using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        /// <summary>
        /// Represents on tournament, with all of the rounds, matchups, prizes and outcomes.
        /// </summary>
        public int Id { get; set; }
        //unique identifier for the tournament
        public string TournamentName { get; set; }
        //name given to the tournament
        public decimal EntryFee { get; set; }
        //amount of money each team needs to put up to enter
        public List<Models.TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        // the set of teams that have been enterd
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        //th list of prizes for the various places
        public List<List<MatchupModel>> Rounds {get;set;} = new List<List<MatchupModel>>();
        //matchups per round
    }
}
