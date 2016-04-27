using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebMapGoogleScreen : Screen
    {
        private WebMapGoogle _webMapGoogle;
        
        public override void OnLoading()
        {
            GPS.StartTracking(1);
            System.Threading.Thread.Sleep(100);
            DConsole.WriteLine(string.Format(GPS.StartTracking().ToString()));
            DConsole.WriteLine(string.Format(GPS.CurrentLocation.ToString()));
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _webMapGoogle = new WebMapGoogle();
            _webMapGoogle.Visible = true;
            _webMapGoogle.CssClass = "WebMapGoogle";
            _webMapGoogle.Id = "ID OF WEB MAP GOOGLE";
            GPS.Update();
            _webMapGoogle.AddMarker("marker", GPS.CurrentLocation.Latitude, GPS.CurrentLocation.Longitude, "red");


            vl.AddChild(_webMapGoogle);
            vl.AddChild(new Button("ID", ID_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ID_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(_webMapGoogle.Id));
        }
    }
}