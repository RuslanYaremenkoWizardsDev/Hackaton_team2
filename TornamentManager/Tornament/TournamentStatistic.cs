using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TornamentManager.Stats;

namespace TornamentManager.Tornament
{
    public class TournamentStatistic : MainWindow
    {
        TournamentsStatistics tournamentsStatistics = new TournamentsStatistics();
        public TournamentStatistic()
        {
            CupNumber_textBox.Text = Convert.ToString(tournamentsStatistics.CupStats.Number);
            CupActive_textBox.Text = Convert.ToString(tournamentsStatistics.CupStats.Active);
            CupFinished_textBox.Text = Convert.ToString(tournamentsStatistics.CupStats.Finished);
            CupCancelled_textBox.Text = Convert.ToString(tournamentsStatistics.CupStats.Cancelled);
            ChampionshipNumber_textBox.Text = Convert.ToString(tournamentsStatistics.ChampionshipStats.Number);
            ChampionshipActive_textBox.Text = Convert.ToString(tournamentsStatistics.ChampionshipStats.Active);
            ChampionshipFinished_textBox.Text = Convert.ToString(tournamentsStatistics.ChampionshipStats.Finished);
            ChampionshipCancelled_textBox.Text = Convert.ToString(tournamentsStatistics.ChampionshipStats.Cancelled);
            TotalNumber_textBox.Text = Convert.ToString(tournamentsStatistics.TotalStats.Number);
            TotalActive_textBox.Text = Convert.ToString(tournamentsStatistics.TotalStats.Active);
            TotalFinished_textBox.Text = Convert.ToString(tournamentsStatistics.TotalStats.Finished);
            TotalCancelled_textBox.Text = Convert.ToString(tournamentsStatistics.TotalStats.Cancelled);
        }
    }
}
