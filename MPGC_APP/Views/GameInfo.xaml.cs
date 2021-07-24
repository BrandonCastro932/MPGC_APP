using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameInfo : ContentPage
    {
        public GameInfo()
        {
            InitializeComponent();
            mediaPlayer.HeightRequest = 1;
            GetYTGameMusicAsync("QzMFg3SfXZA");
        }

        private void CmdGameStateChange(object sender, EventArgs e)
        {

            if (!PkPicker.IsFocused)
            {
                PkPicker.IsVisible = true;
                PkPicker.Focus();
            }
        }

        private void CmdHidePicker(object sender, FocusEventArgs e)
        {
            PkPicker.IsVisible = false;
            
        }

        public async void GetYTGameMusicAsync(string videoId)
        {
            var youtube = new YoutubeClient();

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (streamInfo != null)
            {
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                string source = streamInfo.Url;


                mediaPlayer.Source = source;
                mediaPlayer.AutoPlay = true;
                mediaPlayer.Volume = 50;
                mediaPlayer.HeightRequest = 0;

            }
        }
    }
}