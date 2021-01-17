using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }
        public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int.TryParse(placeNumber, out int placeNumVal);
            PlaceNumber = placeNumVal;

            decimal.TryParse(prizeAmount, out decimal prizeAmtValue);
            PrizeAmount = prizeAmtValue;

            double.TryParse(prizePercentage, out double prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }

        // TO DO -- Figure out why it gives an error with out this here.
        public PrizeModel()
        {
        }
    }
    
}
