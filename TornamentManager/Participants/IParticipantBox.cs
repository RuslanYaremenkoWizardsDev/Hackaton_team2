using System.Windows;

namespace TornamentManager.Participants
{
    public interface IParticipantBox
    {
        public int ID { get; }
        void Button_Move_Click(object sender, RoutedEventArgs e) { }
    }
}
