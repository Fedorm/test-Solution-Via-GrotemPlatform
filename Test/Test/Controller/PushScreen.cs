using System;
using BitMobile.ClientModel3.UI;
using ClientModel3.MD;

namespace Test
{
    public class PushScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);


            vl.AddChild(new Button("Push to some devices", PushMessage_OnClick));
            vl.AddChild(new Button("Receive Push", ReceivePush_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void PushMessage_OnClick(object sender, EventArgs e)
        {
            PushNotification.PushMessage("Hello", new[] { "15f3904b-942b-11e5-bb64-f8a963e4bf15", "8d3e3420-f723-11e5-80fd-902b3416d383" });
        }

 private void ReceivePush_OnClick(object sender, EventArgs e)
        {
           
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}