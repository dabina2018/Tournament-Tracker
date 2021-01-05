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
    public partial class CreatePrize : Page
    {
        public CreatePrize()
        {
            InitializeComponent();
            //IDataConnection data = new InitializeConnections(true, true);
        }

        private void createPrize_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeName_textbx.Text, placeNumber_textbx.Text, prizeAmt_textbx.Text, prizePercentage_textbx.Text);
                
                GlobalConfig.Connection.CreatePrize(model);

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
                Console.WriteLine("The place number entered should be a value between 1 and 10");
                return false;
            }
            if (placeNumber < 1 || placeNumber_textbx.Text.Length == 0)
            {
                Console.WriteLine("Please enter a place number value between 1 and 10");
                return false;
            }
            if (placeName_textbx.Text.Length == 0)
            {
                Console.WriteLine("Please enter a place name, i.e. '1st, 2nd, 3rd'");
                return false;
            }
            decimal prizeAmt;
            double prizePercent;
            bool prizeAmtTest = decimal.TryParse(prizeAmt_textbx.Text, out prizeAmt);
            bool prizePercentageTest = double.TryParse(prizePercentage_textbx.Text, out prizePercent);
            if (prizeAmtTest == false || prizePercentageTest == false)
            {
                Console.WriteLine("Prize amount must be a decimal value 0.00");
                return false;
            }
            if (prizeAmt <= 0 && prizePercent > 100) return false;


            return output;
        }
    }
}
