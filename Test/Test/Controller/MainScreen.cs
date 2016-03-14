using System;
using System.Text;
using System.Net;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class MainScreen : Screen
    {
        Button syncButton;

        public override void OnLoading()
        {
            var vl = new VerticalLayout();

            syncButton = new Button();
            syncButton.OnClick += SyncButton_OnClick;

            vl.AddChild(syncButton);
            vl.AddChild(new Button("Make new photo", MakePhotoButton_OnClick));
            vl.AddChild(new Button("Web Request", MakeWebRequest_OnClick));
            vl.AddChild(new Button("Exit", ExitButton_OnClick));
            vl.AddChild(new Button("TestThirdScreen", TestThirdScreenButton_OnClick));
            AddChild(vl);
        }

        public override void OnShow()
        {
            UpdateSyncButton();
        }

        private void UpdateSyncButton()
        {
            syncButton.Text = String.Format("Sync {0} photos", DB.GetCountOfUnsyncedPhotos());
        }

        void SyncButton_OnClick(object sender, EventArgs e)
        {
            YandexPhoto.SyncPhotos();
            UpdateSyncButton();
        }

        void MakePhotoButton_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("Forward");
        }


        void MakeWebRequest_OnClick(object sender, EventArgs e)
        {

            WebRequest req = WebRequest.Create("http://bitmobile1.bt/bitmobileX/platform/device/GetClientMetadata");
            DConsole.WriteLine(String.Format("Web Request Created"));
            string svcCredentials =
                Convert.ToBase64String(Encoding.ASCII.GetBytes("fm" + ":" + "fm"));
            req.Headers.Add("Authorization", "Basic " + svcCredentials);

            DConsole.WriteLine(String.Format("Headers added"));

            using (WebResponse resp = req.GetResponse()) { }

            DConsole.WriteLine(String.Format("The response is received"));


        }

        void ExitButton_OnClick(object sender, EventArgs e)
        {
            Application.Terminate();
        }


        void TestThirdScreenButton_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoAction("Button");
        }
    }
}
