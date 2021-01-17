using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess;
using System.ComponentModel;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for TournamentDashboard.xaml
    /// </summary>
    public partial class TournamentDashboard : Window
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournaments_All();
        public TournamentDashboard()
        {
            InitializeComponent();
            InitializeTournamentList();
        }
        private void InitializeTournamentList()
        {
            existingTournament_ListBx.ItemsSource = tournaments;
            existingTournament_ListBx.DisplayMemberPath = "TournamentName";
        }
        private void CreateTournament_Btn_Click(object sender, RoutedEventArgs e)
        {
            CreateTournament page = new CreateTournament(this);            
            page.Show();
            // TODO -- refresh list of tournaments after a new tournament is created
            
        }
        public void TournamentComplete(TournamentModel model)
        {
            tournaments.Add(model);
            InitializeTournamentList();
        }
        private void LoadTournament_Btn_Click(object sender, RoutedEventArgs e)
        {
            TournamentModel tm = (TournamentModel)existingTournament_ListBx.SelectedItem;
            TournamentViewer page = new TournamentViewer(tm);
            page.Show();
            
        }

    }
}
