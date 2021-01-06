using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournament : Page
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournament()
        {
            InitializeComponent();
            InitializeLists();
        }
        private void InitializeLists()
        {
            selectTeam_listbx.ItemsSource = null;
            selectTeam_listbx.ItemsSource = availableTeams;
            selectTeam_listbx.DisplayMemberPath = "TeamName";

            tournamentTeams_ListBx.ItemsSource = null;
            tournamentTeams_ListBx.ItemsSource = selectedTeams;
            tournamentTeams_ListBx.DisplayMemberPath = "TeamName";

            prizes_ListBx.ItemsSource = null;
            prizes_ListBx.ItemsSource = selectedPrizes;
            prizes_ListBx.DisplayMemberPath = "PlaceName";
        }

        private void addTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            TeamModel tm = (TeamModel)selectTeam_listbx.SelectedItem;
            if(tm != null)
            {
                availableTeams.Remove(tm);
                selectedTeams.Add(tm);

                InitializeLists();
            }
        }

        private void createPrizeBtn_Click(object sender, RoutedEventArgs e)
        {
            //Call the Create Prize Form
            CreatePrize page = new CreatePrize();
            this.NavigationService.Navigate(page);
            //Get back from the form a PrizeModel
            //Take the PrizeModel and put it into our list of slected prizes
        }


    }
}
