using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class FileSystemScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);


            vl.AddChild(new Button("LastError", LastError_OnClick));
            vl.AddChild(new Button("Delete Private And Shared", Delete_OnClick));
            vl.AddChild(new Button("Sync shared + private", SyncSharedPrivate_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void SyncSharedPrivate_OnClick(object sender, EventArgs e)
        {
            FileSystem.SyncShared();
        }

        private void LastError_OnClick(object sender, EventArgs e)
        {
            //DConsole.WriteLine(string.Format(FileSystem.LastError.ToString()));
        }

        private void Delete_OnClick(object sender, EventArgs e)
        {
            FileSystem.ClearPrivate();
            FileSystem.ClearShared();
        }
    }
}