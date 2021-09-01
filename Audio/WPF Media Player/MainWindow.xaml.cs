using System;
using System.Media;
using System.Windows;
using System.Windows.Media;

namespace Audio_and_Video
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSound1_Click(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Asterisk.Play();
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\Alarm01.wav";
            soundPlayer.Play();
        }

        private void buttonSound2_Click(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Beep.Play();
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\Alarm02.wav";
            soundPlayer.Play();
        }

        private void buttonSound3_Click(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Exclamation.Play();
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\Alarm03.wav";
            soundPlayer.Play();
        }

        private void buttonSound4_Click(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Hand.Play();
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\Alarm04.wav";
            soundPlayer.Play();
        }

        private void buttonSound5_Click(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Question.Play();
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\Alarm05.wav";
            soundPlayer.Play();
        }

        private void buttonSound6_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Windows\Media\Alarm06.wav";
            soundPlayer.Play();
        }

        private void buttonPlayMedia_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri(@"A:\Temp\Clay Walker - Bury The Shovel.mp3"));
            mediaPlayer.Play();
            //mediaPlayer.BeginAnimation(DependencyProperty dp, AnimationTimeline animation);
        }

        private void buttonStopMedia_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void buttonPauseMedia_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = sliderVolume.Value;
        }
    }
}
