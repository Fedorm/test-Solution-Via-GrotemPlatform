using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DatabaseScreen : Screen
    {

        public Database db;
        public override void OnLoading()
        {

            Initialize();
            
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);


            vl.AddChild(new Button("Initialize Database", Initialize));
            vl.AddChild(new Button("Syncrho", Synchronization));

            vl.AddChild(new Button("Back", Back_OnClick));
        }


        void Initialize(object sender, EventArgs e)
        {
            db = new Database();
            db.CreateFromModel();

            
            db.PerformSync(@"http://192.168.106.141/bitmobile/synchro/device", "sr", "sr", OnSyncComplete, "sync complete");
            DConsole.WriteLine("Initialize OK!");
        }
        private void OnSyncComplete(object sender, ResultEventArgs<bool> resultEventArgs)
        {
        }



        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
 private void Synchronization(object sender, EventArgs e)
        {
            db.PerformSync(@"http://192.168.106.141/bitmobile/synchro/device", "sr", "sr", OnSyncComplete, "sync complete");
            DConsole.WriteLine("Synchronization OK!");
        }

 
    }
}