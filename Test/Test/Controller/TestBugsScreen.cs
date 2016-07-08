using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestBugsScreen : Screen
    {


        public override void OnLoading()
        {

            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Test simple toast", Toast_OnButtonClick));
            vl.AddChild(new Button("Test snackbar with OK button", TestSnackbar_OnButtonClick));



            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(new Button("Test Bool", CheckListDecimal_OnLostFocus));
        }




        private void TestSnackbar_OnButtonClick(object sender, EventArgs eventArgs)
        {
            Toast.MakeSnackbar("Some text", "OK", SnackBar_OnOkButtonClickedHandler, "OK");
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

        internal void CheckListDecimal_OnLostFocus(object sender, EventArgs e)
        {
            var val = true;
            DConsole.WriteLine("1 var val = true; CheckNotBool(val);");
            CheckNotBool(val);
        }

        private void CheckNotBool(bool val)
        {
            DConsole.WriteLine("Внутри функции CheckNotBool. значение равно = " + val);
        }
    }
}
