using System;
using System.Text;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestBugsScreen : Screen
    {
        VerticalLayout vl;
        public Database db;
      
      
        public override void OnLoading()
        {
            GpsTracking.IsBestAccuracy = true;
            GpsTracking.MinInterval = 2;
            GpsTracking.MinDistance = 2;
            GpsTracking.DistanceFilter = 1;
            GpsTracking.SendInterval = 5;
            GpsTracking.SendUrl = "http://bitmobile1.bt/bitmobile3";
            GpsTracking.UserId = "";

            //На следующей строчке падает.
            var isStart = GpsTracking.Start();
            Initialize();
            
        }
        
        private void Initialize()
        {
          vl = new VerticalLayout();
            AddChild(vl);

            //vl.AddChild(new Button("Test simple toast", Toast_OnButtonClick));
            //vl.AddChild(new Button("Test snackbar with OK button", TestSnackbar_OnButtonClick));
            //vl.AddChild(new Button("Test", Test_OnButtonClick));
       



            vl.AddChild(new Button("Back", Back_OnClick));
    





        }
        private void InitDb(object sender, EventArgs e)
        {
            db = new Database();
            db.CreateFromModel();
            DConsole.WriteLine("Initialize OK!");
        }


        private void TestSnackbar_OnButtonClick(object sender, EventArgs eventArgs)
        {
            Toast.MakeSnackbar("Some text", "OK", SnackBar_OnOkButtonClickedHandler, "OK");
        }
        private void Test_OnButtonClick(object sender, EventArgs eventArgs)
        {
         

        }
       

        private void SnackBar_OnOkButtonClickedHandler(object sender, ResultEventArgs<bool> resultEventArgs)
        {
            Toast.MakeToast(sender + " button clicked on snackbar");
        }

        private void Toast_OnButtonClick(object sender, EventArgs e)
        {
            Toast.MakeToast("Simple toast");
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void DbPerformSyncAsync(object sender, EventArgs e)
        {
            try
            {
                db.PerformSyncAsync(@"http://192.168.106.141/bitmobile/synchro2/device", "Sr", "Sr", OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformSyncAsync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }
        private void OnSyncComplete(object sender, ResultEventArgs<bool> resultEventArgs)
        {
            DConsole.WriteLine("OnSyncComplete ok");
        }

    }
}
