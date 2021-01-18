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
    /// Interaction logic for CreatePrize.xaml
    /// </summary>
    public partial class CreatePrize : Window
    {
        IPrizeRequestor callingForm;
        public CreatePrize(IPrizeRequestor caller)
        {
            InitializeComponent();
            callingForm = caller; //makes caller (prizemodel) available to create prize method
        }
        private void CreatePrize_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(placeNumber_textbx.Text, placeName_textbx.Text, prizeAmt_textbx.Text, prizePercentage_textbx.Text);
                
                GlobalConfig.Connection.CreatePrize(model);
                MessageBox.Show("Prize was submitted");
                callingForm.PrizeComplete(model);
                this.Close();

                placeName_textbx.Text = "";
                placeNumber_textbx.Text = "";
                prizeAmt_textbx.Text = "0";
                prizePercentage_textbx.Text = "0";
            }
            else { MessageBox.Show("This form has invalid information. Please check it and try again."); }  
        }
        private bool ValidateForm()
        {
            //validate user form input
            bool output = true;
            bool placeNumTest = int.TryParse(placeNumber_textbx.Text, out int placeNumber);
            if (!placeNumTest)
            {
                MessageBox.Show("The place number entered should be a whole number value");
                return false;
            }
            if (placeNumber < 1 || placeNumber_textbx.Text.Length == 0)
            {
                MessageBox.Show("The place number entered should be a whole number value");
                return false;
            }
            if (placeName_textbx.Text.Length == 0)
            {
                MessageBox.Show("Please enter a place name, i.e. '1st, 2nd, 3rd'");
                return false;
            }
            if (prizeAmt_textbx.Text.Length == 0 && prizePercentage_textbx.Text.Length == 0)
            {
                MessageBox.Show("Please enter either a prize percentage or a prize dollar amount");
                return false;
            }
            if (prizeAmt_textbx.Text == "0" && prizePercentage_textbx.Text == "0")
            {
                MessageBox.Show("Enter either a prize percentage or a prize dollar amount, NOT both.");
                return false;
            }
            decimal prizeAmt;
            double prizePercent;
            bool prizeAmtTest = decimal.TryParse(prizeAmt_textbx.Text, out prizeAmt);
            bool prizePercentageTest = double.TryParse(prizePercentage_textbx.Text, out prizePercent);
            if (prizeAmtTest == false || prizePercentageTest == false)
            {
                MessageBox.Show("The prize amount should be a decimal value & The prize percentage should be a whole number");
                return false;
            }
            if (prizeAmt < 0 || prizePercent > 100) 
            {
                MessageBox.Show("The prize amount should be greater than '0' & The prize percentage should be less than 100");
                return false;
            }
            
            return output;
        }
    }
}
