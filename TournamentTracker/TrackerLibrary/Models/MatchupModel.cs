using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        //unique identifier for the matchup
        public int Id { get; set; }
        //the set of teams that were involved in this match
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        //Id from databsed, only used to lookup the winner
        public int WinnerId { get; set; }
        //the winner of the match
        public TeamModel Winner { get; set; }
        //which round this match is a part of 
        public int MatchupRound { get; set; }
    }
}
