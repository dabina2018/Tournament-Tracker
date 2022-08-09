using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;

namespace TournamentTrackerUI
{
    public interface IPrizeRequestor
    {
        void PrizeComplete(PrizeModel model);
    }
}
