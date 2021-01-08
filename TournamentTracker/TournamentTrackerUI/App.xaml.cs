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


namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary> 
    public partial class App : Application
    {
        /* [STAThread()]
         public static void Main()
         {
             TournamentTrackerUI.App app = new TournamentTrackerUI.App();
             app.InitializeComponent();
             app.Run();
         }
        */
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            TrackerLibrary.DataAccess.GlobalConfig.InitializeConnections(TrackerLibrary.DatabaseType.Sql);
        }
    }
}
