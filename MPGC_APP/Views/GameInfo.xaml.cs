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
           
            /*Esto pone un titulo en el shell bar
            Label r = new Label();
            r.Text = "Nier";
            Shell.SetTitleView(this, (View)r);
            */
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
            Loading.IsVisible = true;
            Content.IsVisible = false;

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);

            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (streamInfo != null)
            {
                string source = streamInfo.Url;

                mediaPlayer.Source = source;

                mediaPlayer.Volume = 15;
                mediaPlayer.HeightRequest = 0;
                mediaPlayer.AutoPlay = true;
                while (mediaPlayer.State == Octane.Xamarin.Forms.VideoPlayer.Constants.PlayerState.Idle)
                {

                }
                Loading.IsVisible = false;
                Content.IsVisible = true;
            }
        }

        private void PkPicker_Focused(object sender, FocusEventArgs e)
        {
            PkPicker.IsVisible = false;
        }
        
    }
}