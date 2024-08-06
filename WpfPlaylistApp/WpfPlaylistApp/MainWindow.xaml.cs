using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfPlaylistApp
{
    public partial class MainWindow : Window
    {
        private DoublyLinkedList playlist;

        public MainWindow()
        {
            InitializeComponent();
            playlist = new DoublyLinkedList();
            UpdatePlaylist();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string track = TrackTextBox.Text;
            if (!string.IsNullOrEmpty(track))
            {
                playlist.AddTrack(track);
                TrackTextBox.Clear();
                UpdatePlaylist();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string track = TrackTextBox.Text;
            if (!string.IsNullOrEmpty(track))
            {
                if (playlist.RemoveTrack(track))
                {
                    MessageBox.Show($"Track \"{track}\" removed.");
                    UpdatePlaylist();
                }
                else
                {
                    MessageBox.Show($"Track \"{track}\" not found in the playlist.");
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string nextTrack = playlist.NextTrack();
            if (nextTrack != null)
            {
                CurrentTrackTextBlock.Text = $"Playing next track: {nextTrack}";
                UpdatePlaylist();
            }
            else
            {
                MessageBox.Show("No more tracks ahead.");
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            string prevTrack = playlist.PrevTrack();
            if (prevTrack != null)
            {
                CurrentTrackTextBlock.Text = $"Playing previous track: {prevTrack}";
                UpdatePlaylist();
            }
            else
            {
                MessageBox.Show("No more tracks behind.");
            }
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            playlist.ShuffleTracks();
            MessageBox.Show("Playlist shuffled.");
            UpdatePlaylist();
        }

        private void TrackTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(TrackTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void UpdatePlaylist()
        {
            List<string> tracks = playlist.GetTracks();
            PlaylistListBox.Items.Clear();
            foreach (var track in tracks)
            {
                PlaylistListBox.Items.Add(track);
            }
            CurrentTrackTextBlock.Text = $"Current track: {playlist.CurrentTrack()}";
        }
    }
}
