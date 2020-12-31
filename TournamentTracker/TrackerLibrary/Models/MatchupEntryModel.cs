﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// write a description here... Represents one team in teh matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score for this particular team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represents the score for the matchup that this team came from as the winner.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MatchupEntryModel(double initialScore)
        {
            Console.WriteLine();
        }
    }
}