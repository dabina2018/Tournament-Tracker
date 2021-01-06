using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess;
using System.Linq;

namespace TrackerLibrary
{
    class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModel.csv";

        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file // Convert the tex to List<PrizeMOdel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID
            int currentId = 1;
            if(prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            
            //Add the new record with the new ID
            prizes.Add(model);

            //convert th prizes to list<string>
            //Save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);
            return model;            
        }

        public PersonModel CreatePerson(PersonModel model)
        {

            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            people.Add(model);
            people.SaveToPeopleFile(PeopleFile);
            return model;
        }
        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
            //Find the max ID
            int currentId = 1;
            if(teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id = 1;
            }
            model.Id = currentId;
            teams.Add(model);
            teams.SaveToTeamFile(TeamFile);
            return model;
        }
        public List<PersonModel> GetPerson_All()
        {
            
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            throw new NotImplementedException();
        }

        public List<TeamModel> GetTeam_All()
        {
            //throw new NotImplementedException();
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }
    }
}

