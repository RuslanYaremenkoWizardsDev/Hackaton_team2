using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TornamentManager.Participants
{
    public interface IParticipantBox
    {
        public int ID { get; }
        void Button_Move_Click(object sender, RoutedEventArgs e) { }
    }
}
