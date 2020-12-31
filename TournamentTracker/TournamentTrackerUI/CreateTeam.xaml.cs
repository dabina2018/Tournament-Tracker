using System;
using System.Collections.Generic;
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
using TrackerLibrary.DataAccess;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for CreateTream.xaml
    /// </summary>
    public partial class CreateTream : Page
    {
        public CreateTream()
        {
            InitializeComponent();
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

                GlobalConfig.Connection.CreatePerson(p);
            }
            
        }
        private bool ValidateForm()
        {
            //TODO - Add validation to the form
            if(firstName_textbx.Text.Length == 0)
            {
                return false;
            }
            if(lastName_textbx.Text.Length == 0)
            {
                return false;
            }
            if(cellphone_textbx.Text.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}
