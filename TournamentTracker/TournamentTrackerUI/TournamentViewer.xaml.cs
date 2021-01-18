using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for TournamentViewer.xaml
    /// </summary>
    public partial class TournamentViewer : Window
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewer(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournament = tournamentModel;
            InitializeRoundsLists();
            InitializeMatchupsList();
            LoadPageData();
            LoadRounds();
        }
        private void LoadPageData()
        {
            tournamentName_Label.Content = tournament.TournamentName;
        }
        private void InitializeRoundsLists()
        {
           
            roundComboBx.ItemsSource = rounds;
        }
        private void InitializeMatchupsList()
        {
            matchupListBox.ItemsSource = selectedMatchups;
            matchupListBox.DisplayMemberPath = "DisplayName";
        }
        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int currentRound = 1;
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }
            roundComboBx.SelectedItem = rounds.First();
            LoadMatchups(1);
        }

        private void roundComboBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMatchups((int)roundComboBx.SelectedItem);
        }
        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || (bool)!unplayedRoundCheckBx.IsChecked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }
            if (selectedMatchups.Count > 0)
            {
                LoadMatchupScore(selectedMatchups.First());
            }
            DisplayMatchupInfo();
        }
        private void DisplayMatchupInfo()
        {
            switch (selectedMatchups.Count > 0)
            {
                case true:
                    teamOneLabel.Visibility = Visibility.Visible;
                    teamOneScoreLabel.Visibility = Visibility.Visible;
                    teamOneScore_textbx.Visibility = Visibility.Visible;
                    teamTwoLabel.Visibility = Visibility.Visible;
                    teamTwoScoreLabel.Visibility = Visibility.Visible;
                    vsLabel.Visibility = Visibility.Visible;
                    scoreBtn.Visibility = Visibility.Visible;
                    teamTwoScore_textbx.Visibility = Visibility.Visible;
                    break;
                case false:
                    teamOneLabel.Visibility = Visibility.Collapsed;
                    teamOneScoreLabel.Visibility = Visibility.Collapsed;
                    teamOneScore_textbx.Visibility = Visibility.Collapsed;
                    teamTwoLabel.Visibility = Visibility.Collapsed;
                    teamTwoScoreLabel.Visibility = Visibility.Collapsed;
                    vsLabel.Visibility = Visibility.Collapsed;
                    scoreBtn.Visibility = Visibility.Collapsed;
                    teamTwoScore_textbx.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private  void LoadMatchupScore(MatchupModel m )
        {           
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        
                        teamOneLabel.Content = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreLabel.Content = m.Entries[0].Score.ToString();
                        teamTwoLabel.Content = "<bye>";
                        teamTwoScoreLabel.Content = "0";
                    }
                    else
                    {
                        teamOneLabel.Content = "TBD";
                        teamOneScoreLabel.Content = "TBD";
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoLabel.Content = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreLabel.Content = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoLabel.Content = "TBD";
                        teamTwoScoreLabel.Content = "TBD";
                    }
                }
            }
        }
        private void matchupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(matchupListBox.SelectedIndex != -1)
            {
                LoadMatchupScore((MatchupModel)matchupListBox.SelectedItem);
            }
            else
            {
                return;
            }
            
        }
        private void unplayedRoundCheckBx_Checked(object sender, RoutedEventArgs e)
        {
            LoadMatchups((int)roundComboBx.SelectedItem);
            //TODO -- refresh matchups list after box is unchecked
        }

        private void scoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (matchupListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Matchup from the List");
            }
            else
            {
                MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
                double teamOneScore = 0;
                double teamTwoScore = 0;
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting != null)
                        {
                            bool scoreValid = double.TryParse(teamOneScore_textbx.Text, out teamOneScore);
                            if (scoreValid)
                            {
                                m.Entries[0].Score = teamOneScore;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1; Score must be an integer");
                            return;
                        }
                    }
                    if (i == 1)
                    {

                        bool scoreValid = double.TryParse(teamTwoScore_textbx.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2; Score must be an integer");
                        }
                    }
                }
                if (teamOneScore > teamTwoScore)
                {
                    //Team one wins
                    m.Winner = m.Entries[0].TeamCompeting;
                    MessageBox.Show("Team One is the Winner");
                    
                }
                else if (teamOneScore < teamTwoScore)
                {
                    //Team one wins
                    m.Winner = m.Entries[1].TeamCompeting;
                    MessageBox.Show("Team Two is the Winner");
                }
                else
                {
                    MessageBox.Show("Tie Game! there is no winner");
                }
                teamOneScore_textbx.Text = "";
                teamTwoScore_textbx.Text = "";
                LoadMatchups((int)roundComboBx.SelectedItem);

                GlobalConfig.Connection.UpdateMatchup(m);
            }
            
        }
    }
}
