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
            matchupListBox.DisplayMemberPath= "DisplayName";
        }
        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int currentRound = 1;
            foreach(List<MatchupModel> matchups in tournament.Rounds)
            {
                if(matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }            
            LoadMatchups(1);
        }

        private void roundComboBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMatchups((int)roundComboBx.SelectedItem);
        }
        private void LoadMatchups( int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if(matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner != null || (bool)!unplayedRoundCheckBx.IsChecked)
                        {
                            selectedMatchups.Add(m); 
                        }
                    }
                }
            }
            
            LoadMatchupScore(selectedMatchups.First());
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
            LoadMatchupScore((MatchupModel)matchupListBox.SelectedItem);
        }

        private void unplayedRoundCheckBx_Checked(object sender, RoutedEventArgs e)
        {
            LoadMatchups((int)roundComboBx.SelectedItem);
        }

        private void scoreBtn_Click(object sender, RoutedEventArgs e)
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
                        //teamOneLabel.Content = m.Entries[0].TeamCompeting.TeamName;
                        //double scoreVal = 0;
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
                    ///teamTwoLabel.Content = m.Entries[1].TeamCompeting.TeamName;
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
            if(teamOneScore > teamTwoScore )
            {
                //Team one wins
                m.Winner = m.Entries[0].TeamCompeting;
            }
            else if
            {
                //Team one wins
                m.Winner = m.Entries[1].TeamCompeting;
            }
            else
            {
                MessageBox.Show("Tie Game! there is no winner");
            }
        }
    }
}
