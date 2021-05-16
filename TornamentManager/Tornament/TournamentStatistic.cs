using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace TornamentManager.Tornament
{
    public class TournamentStatistic : MainWindow
    {        
        int CupNumber { get; set; }
        int CupActive { get; set; }
        int CupFinished { get; set; }
        int CupCancelled { get; set; }
        int ChampionshipNumber { get; set; }
        int ChampionshipActive { get; set; }
        int ChampionshipFinished { get; set; }
        int ChampionshipCancelled { get; set; }
        int totalNumber;
        int totalActive;
        int totalFinished;
        int totalCancelled;
        
        public TournamentStatistic()
        {
            while (true)
            {
                
            }
            totalNumber = CupNumber + ChampionshipNumber;
            totalActive = CupActive + ChampionshipActive;
            totalFinished = CupFinished + ChampionshipFinished;
            totalCancelled = CupCancelled + ChampionshipCancelled;
            CupNumber_textBox.Text = Convert.ToString(CupNumber);
            CupActive_textBox.Text = Convert.ToString(CupActive);
            CupFinished_textBox.Text = Convert.ToString(CupFinished);
            CupCancelled_textBox.Text = Convert.ToString(CupCancelled);
            ChampionshipNumber_textBox.Text = Convert.ToString(ChampionshipNumber);
            ChampionshipActive_textBox.Text = Convert.ToString(ChampionshipActive);
            ChampionshipFinished_textBox.Text = Convert.ToString(ChampionshipFinished);
            ChampionshipCancelled_textBox.Text = Convert.ToString(ChampionshipCancelled);
            TotalNumber_textBox.Text = Convert.ToString(totalNumber);
            TotalActive_textBox.Text = Convert.ToString(totalActive);
            TotalFinished_textBox.Text = Convert.ToString(totalFinished);
            TotalCancelled_textBox.Text = Convert.ToString(totalCancelled);
        }
    }
}
