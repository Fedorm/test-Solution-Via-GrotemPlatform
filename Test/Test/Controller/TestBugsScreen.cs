using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestBugsScreen : Screen
    {


        public override void OnLoading()
        {
            //DConsole.WriteLine("Проверимка вообще проброс ошибочек");
            //var nolusichek = 0;
            //var res = 10 / nolusichek;
            //DConsole.WriteLine("поделили на нолик. есть ошибка. ");

            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Test simple toast", Toast_OnButtonClick));
            vl.AddChild(new Button("Test snackbar with OK button", TestSnackbar_OnButtonClick));



            vl.AddChild(new Button("Back", Back_OnClick));
           




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


    }
}
