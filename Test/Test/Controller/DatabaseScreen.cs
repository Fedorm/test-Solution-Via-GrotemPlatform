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


            vl.AddChild(new Button("Initialize Database", InitDb));
            vl.AddChild(new Button("DB PerformSync", DbPerformSync));
            vl.AddChild(new Button("DB PerformSync Async", DbPerformSyncAsync));
            vl.AddChild(new Button("DB Perform Full Sync", DbPerformFullSync));
            vl.AddChild(new Button("DB Perform Full Sync Async", DbPerformFullSyncAsync));

            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void InitDb(object sender, EventArgs e)
        {
            db = new Database();
            db.CreateFromModel();
            DConsole.WriteLine("Initialize OK!");
        }


        private void DbPerformSync(object sender, EventArgs e)
        {
            try
            {
                db.PerformSync(@"http://192.168.106.141/bitmobile/synchro/device", "sr", "sr", OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformSync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformSyncAsync(object sender, EventArgs e)
        {
            try
            {
                db.PerformSyncAsync(@"http://192.168.106.141/bitmobile/synchro/device", "sr", "sr", OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformSyncAsync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformFullSyncAsync(object sender, EventArgs e)
        {
            try
            {
                db.PerformFullSyncAsync(@"http://192.168.106.141/bitmobile/synchro/device", "sr", "sr", OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformFullSyncAsync OK!");
            }
            catch (Exception ex)
            {
                DConsole.WriteLine(ex.Message);
            }
        }

        private void DbPerformFullSync(object sender, EventArgs e)
        {
            try
            {
                db.PerformFullSync(@"http://192.168.106.141/bitmobile/synchro/device", "sr", "sr", OnSyncComplete,
                    "sync complete");
                DConsole.WriteLine("DbPerformFullSync OK!");
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

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}