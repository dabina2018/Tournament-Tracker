using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess;

namespace TournamentTrackerUI
{
    //TODO -- Fix Form labels, half are green and half are black
    /// <summary>
    /// Interaction logic for CreateTream.xaml
    /// </summary>
    public partial class CreateTeam : Window
    {
        //TODO - Implement as Observable Collection, use INotifyPropertyChanged - https://www.wpf-tutorial.com/data-binding/responding-to-changes/
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All(); //selectTeamMember dropdown
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>(); // teamMember dropdown
        private ITeamRequester callingForm;
        public CreateTeam(ITeamRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            //SampleData();
            TeamListFunctionality();
        }
      
        private void SampleData()
        {
            availableTeamMembers.Add(new PersonModel {FirstName = "Tim", LastName = "Corey" });
            availableTeamMembers.Add(new PersonModel {FirstName = "Betty", LastName = "Boop" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Juliet", LastName = "Montague" });
        }
        private void TeamListFunctionality()
        {
            selectTeamMember_dropdown.ItemsSource = null;
            selectTeamMember_dropdown.ItemsSource = availableTeamMembers;
            selectTeamMember_dropdown.DisplayMemberPath = "FullName";

            teamMember_ListBx.ItemsSource = null;
            teamMember_ListBx.ItemsSource = selectedTeamMembers;
            teamMember_ListBx.DisplayMemberPath = "FullName";
        }

        private void CreateMemberField_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = firstName_textbx.Text;
                p.LastName = lastName_textbx.Text;
                p.EmailAddress = email_textbx.Text;
                p.CellphoneNumber = cellphone_textbx.Text;

                p = GlobalConfig.Connection.CreatePerson(p);
                selectedTeamMembers.Add(p);
                TeamListFunctionality();

                firstName_textbx.Text = "";
                lastName_textbx.Text = "";
                email_textbx.Text = "";
                cellphone_textbx.Text = "";
            }
            else
            {
                MessageBox.Show("There were mistakes in one of the form fields .");
            }
            
        }
        private bool ValidateForm()
        {
            if(firstName_textbx.Text.Length == 0)
            {
                return false;
            }
            if(lastName_textbx.Text.Length == 0)
            {
                return false;
            }
            return true;
        }
        private void AddMember_Btn_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMember_dropdown.SelectedItem ;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);
                TeamListFunctionality(); 
            }
        }

        private void RemoveSelected_Btn_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)teamMember_ListBx.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                TeamListFunctionality(); 
            }
        }

        private void CreateTeam_Btn_Click(object sender, RoutedEventArgs e)
        {
            TeamModel tm = new TeamModel();
            tm.TeamName = teamName_textbx.Text;
            tm.TeamMembers = selectedTeamMembers;
            GlobalConfig.Connection.CreateTeam(tm);
            callingForm.TeamComplete(tm);
            this.Close();
        }

      
    }
}
