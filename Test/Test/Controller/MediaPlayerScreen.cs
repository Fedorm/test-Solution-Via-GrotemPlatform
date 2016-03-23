using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class MediaPlayerScreen : Screen
    {
        private MediaPlayer _mediaPlayer;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Visible = true;
            _mediaPlayer.Id = "Id Of MediaPlayer";
            _mediaPlayer.CssClass = "MediaPlayer";
            _mediaPlayer.Path = "Image//clip.mp4";

            vl.AddChild(new TextView("YOU CAN SEE MEDIAPLAYER IN NEXT VERSION"));
            vl.AddChild(new Button("Play", Play_OnClick));
            vl.AddChild(new Button("Pause", Pause_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
            //vl.AddChild(_mediaPlayer);

        }

        private void Play_OnClick(object sender, EventArgs e)   
        {
            _mediaPlayer.Play();
        }

        private void Pause_OnClick(object sender, EventArgs e)
        {
            _mediaPlayer.Pause();
        }

       


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}