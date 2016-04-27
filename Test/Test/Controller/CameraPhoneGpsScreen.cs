using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class CameraPhoneGpsScreen : Screen
    {
        private TextView text;
        private EditText editText;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            text = new TextView();
            text.Text = "89119901150";

            editText = new EditText();
            
            

            vl.AddChild(text);
            vl.AddChild(new Button("Make Call", Phone_OnClick));
            vl.AddChild(new Button("Camera MakeSnapshot", Camera_OnClick));
            vl.AddChild(new Button("Dialog", Dialog_OnClick));
            vl.AddChild(editText);
            vl.AddChild(new Button("Copy To Clipboard", CopyToClipboard_OnClick));
            vl.AddChild(new Button("From Clipboard To Dconsole", FromClipboardToConsole_OnClick));
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void CopyToClipboard_OnClick(object sender, EventArgs e)
        {
            Clipboard.SetString(editText.Text);
        }

        private void FromClipboardToConsole_OnClick(object sender, EventArgs e)
        {
            DConsole.WriteLine(string.Format(Clipboard.HasStringValue.ToString()));
            DConsole.WriteLine(Clipboard.GetString());
        }

        private void Phone_OnClick(object sender, EventArgs e)
        {
            Phone.Call(text.Text);
        }

        private void DconsoleWriteLine(object sender, ResultEventArgs<bool> args)
        {
            DConsole.WriteLine(args.Result.ToString());
        }

        private void Dialog_OnClick(object sender, EventArgs e)
        {
            Dialog.Alert("Test", Alert_Handler, null, "ok");
        }

        private void Alert_Handler(object sender, ResultEventArgs<int> args)
        {
            DConsole.WriteLine(args.Result.ToString());
            Dialog.Ask("Are you ok ?", Ask_Handler);
        }

        private void Ask_Handler(object sender, ResultEventArgs<Dialog.Result> args)
        {
            if (args.Result == Dialog.Result.Yes)
            {
                Console.WriteLine("That's good");
                Dialog.DateTime("What time is is ?", DateTime_Handler);
            }
            else if (args.Result == Dialog.Result.No)
            {
                Console.WriteLine("That's bad");
                Dialog.DateTime("What time is is ?", DateTime_Handler);
            }
        }

        private void DateTime_Handler(object sender, ResultEventArgs<DateTime> args)
        {
            DConsole.WriteLine(args.Result.ToShortTimeString());
        }

        private void Camera_OnClick(object sender, EventArgs e)
        {
            Camera.MakeSnapshot("//private//test.jpg", 5, DconsoleWriteLine);
        }
    }
}