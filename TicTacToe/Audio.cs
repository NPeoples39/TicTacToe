using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TicTacToe
{
    internal class Audio
    {
        public readonly static MediaPlayer Move = LoadAudio("move.mp3", 1);
        private static MediaPlayer LoadAudio(string filename, double volume)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri($"Assets/{filename}", UriKind.Relative));
            player.Volume = volume;
            player.MediaEnded += Player_MediaEnded;
            return player;
        }

        private static void Player_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer p = sender as MediaPlayer;
            p.Stop();
            p.Position = TimeSpan.Zero;
        }
    }
}
