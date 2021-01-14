using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using TrackerLibrary.Models;
using System;

// Load the text file
// Convert the tex to List<PrizeMOdel>
// Find the ID
//Add the new record with the new ID
//convert th prizes to list<string>
//Save the list<string> to the text file

namespace TrackerLibrary.DataAccess
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            //C:\Users\davee\OneDrive\Documents\code\TournamentTracker\dataFiles
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(columns[0]);
                p.PlaceNumber = int.Parse(columns[1]);
                p.PlaceName = columns[2];
                p.PrizeAmount = decimal.Parse(columns[3]);
                p.PrizePercentage = double.Parse(columns[4]);
                output.Add(p);
            }
            return output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];
                output.Add(p);
            }
            return output;
        }
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {
            //id, team name, list of ids seperated by pipe
            // i.e. 3, Tims Team, 1|3|5
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();
            foreach (string line in lines)
            {
                //splits eaach column and pulls out teamId and teamName
                string[] cols = line.Split(",");
                TeamModel tm = new TeamModel();
                tm.Id = int.Parse(cols[0]);
                tm.TeamName = cols[1];

                //splits teamMember column on '|' and puts it into person array
                string[] personIds = cols[2].Split('|');
                foreach (string id in personIds)
                {
                    tm.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }
                output.Add(tm);
            }
            return output;
        }
        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines, string teamFileName, string peopleFileName, string prizeFileName)
        {
            //id, Tournament Name, EntryFee,(id|id|id - teams), (id|id|id - prizes), 
            //               ( id^id^id|id^id^id|id^id^id - rounds <list of matchups>)
            // col0 = id, col1 = tournamentName, col2 = entryfee, col3 = enteredTeams, col4 = prizes, col5 = rounds
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(peopleFileName);
            List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TournamentModel tm = new TournamentModel();
                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|'); //gives "" value
                //====================
                //int teamId;
                //if (int.TryParse(id, out teamId))
                //{ tm.EnteredTeams.Add(teamId; }
                //else { me.ParentMatchup = null; }

                //tm.EnteredTeams.Add(teams.Where(x => x.Id == int.TryParse(id), out int x.Id).First());
                //=================
                foreach (string id in teamIds)
                {
                    int teamId;
                    if (int.TryParse(id, out teamId))
                    {
                        tm.EnteredTeams.Add(teams.Where(x => x.Id == teamId).First()); 
                    }
                }
                if (cols[4].Length == 0) 
                {
                    string[] prizeIds = cols[4].Split('|');
                    foreach (string id in prizeIds)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    } 
                }

                // Capture rounds info
                string[] rounds = cols[5].Split('|');
                
                foreach (string round in rounds)
                {
                    string[] msText = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();
                    //=========================================
                    //int teamId;
                    //if (int.TryParse(id, out teamId))
                    //{tm.EnteredTeams.Add(teams.Where(x => x.Id == teamId).First());  }

                    //ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
                    //==========================================
                    foreach (string matchupModelTextId in msText)
                    {
                        int matchupId=1;
                        if(int.TryParse(cols[3], out matchupId))
                        {
                            ms.Add(matchups.Where(x => x.Id == matchupId).First());
                        }
                    }
                    tm.Rounds.Add(ms);
                }
                output.Add(tm);                
            }
            return output;
        }
        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            //columns: 0=id, 1=entries(pipe delimited by id), 2=winner, 3=matchupRounds
            foreach (string line in lines)
            {
                string[] cols = line.Split(",");
                MatchupModel p = new MatchupModel();
                p.Id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModels(cols[1]);
                if (cols[2].Length == 0)
                {
                    p.Winner = null;
                }
                else
                {
                    p.Winner = LookupTeamById(int.Parse(cols[2]));
                }
               
                p.MatchupRound = int.Parse(cols[3]);
                output.Add(p);
            }
            return output;
        }
        private static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {
            //column structure: 0=id 1=TeamCompeting 2=Score, 3=ParentMatchup
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupEntryModel me = new MatchupEntryModel();
                me.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    me.TeamCompeting = null;
                }
                else
                {
                    me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
                }                
                me.Score = double.Parse(cols[2]);
                int parentId;
                if (int.TryParse(cols[3], out parentId))
                { me.ParentMatchup = LookupMatchupById(parentId); }
                else { me.ParentMatchup = null; }

                output.Add(me);
            }
            return output;
        }


        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (TeamModel tm in models)
            {
                lines.Add($"{tm.Id},{tm.TeamName},{ConvertPeopleListToString(tm.TeamMembers)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            //TournamentId, TournamentName, EntryFee, TeamIds, PrizeList, RoundId
            List<string> lines = new List<string>();
            foreach (TournamentModel tm in models)
            {
                lines.Add($"{tm.Id},{tm.TournamentName},{tm.EntryFee},{ConvertTeamListToString(tm.EnteredTeams)}, {ConvertPrizeListToString(tm.Prizes)}, {ConvertRoundListToString(tm.Rounds)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile, string matchupEntryFile) 
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            int currentId = 1;
            if(matchups.Count > 0)
            {
                //get the top id and add one
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }
            //store the id
            matchup.Id = currentId;
            //adds matchup to current list
            matchups.Add(matchup);
           
            //loop thru each entry, get Id and save
            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                //save the matchup record
                entry.SaveEntryToFile(matchupEntryFile);
            }

            //save to file
            List<string> lines = new List<string>();

            //0=id, 1= entries(pipe delimited by id), 2= winner, 3= matchupRound
            foreach (MatchupModel m in matchups)
            {
                string winner = ""; // make this ukn
                if(m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }
        public static void SaveEntryToFile(this MatchupEntryModel entry, string matchupEntryFile)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            int currentId = 1;
            if (entries.Count > 0) 
            { 
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1; 
            }
            entry.Id = currentId;
            entries.Add(entry);
            
            List<string> lines = new List<string>();

            //Column definitions: 0= id, 1=TeamCompeting, 2=Score, 3=ParentMatchup
            foreach (MatchupEntryModel me in entries)
            {
                string parent = ""; //make this none
                if(me.ParentMatchup != null) { parent = me.ParentMatchup.Id.ToString(); }
                string teamCompeting = ""; //make this unk
                if(me.TeamCompeting != null)
                {
                    teamCompeting = me.TeamCompeting.Id.ToString();
                }
                lines.Add($"{me.Id}, {teamCompeting},{me.Score},{parent}");
            }
            //save to file
            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }
        public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
        {
            // loop thru each round
            foreach (List<MatchupModel> round in model.Rounds)
            {
                //loop thru each matchup, get Id, save matchup record and return Id for new matchup
                foreach (MatchupModel matchup in round)
                {
                    //save to file
                    matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);
                    
                }
            }
        }
        

        private static MatchupModel LookupMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();
            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');
                if(cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModels().First();
                }
            }
            return null;
        }       
        private static TeamModel LookupTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();
            foreach (string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels(GlobalConfig.PeopleFile).First();
                }
            }
            return null;
        }
        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();
            //column structure: 0=id 1=TeamCompeting 2=Score, 3=ParentMatchup
            foreach (string id in ids)
            {
                foreach(string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }                
            }
            output = matchingEntries.ConvertToMatchupEntryModels();
            return output;
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            if (people.Count == 0)
            {
                return "";
            }
            //2|5|
            foreach (PersonModel p in people)
            {
                output += $"{p.Id} |";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";
            if(teams.Count == 0) return"";//change to none
            foreach (TeamModel tm in teams)
            {
                output += $"{tm.Id} | ";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            if(prizes.Count == 0)
            {
                return "";
            }
            foreach(PrizeModel p in prizes)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }        
        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = "";
            if (matchups.Count == 0)
            {
                return "";
            }
            foreach (MatchupModel m in matchups)
            {
                output += $"{m.Id}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            // Rounds - id^id^id|id^id^id|id^id^id
            string output = "";
            if (rounds.Count == 0)
            {
                return "";
            }
            foreach (List<MatchupModel> r in rounds)
            {
                output += $"{ConvertMatchupListToString(r)}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
        {
            string output ="";
            if(entries.Count == 0) { return ""; }
            foreach (MatchupEntryModel e in entries)
            {
                output += $"{ e.Id }|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
