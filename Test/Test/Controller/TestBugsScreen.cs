using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestBugsScreen : Screen
    {
        VerticalLayout vl;
        private bool _foo;


        public override void OnLoading()
        {
          
            Initialize();
        }

        private void Initialize()
        {
          vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Test simple toast", Toast_OnButtonClick));
            vl.AddChild(new Button("Test snackbar with OK button", TestSnackbar_OnButtonClick));
            vl.AddChild(new Button("Test", Test_OnButtonClick));



            vl.AddChild(new Button("Back", Back_OnClick));
    





        }


        private void TestSnackbar_OnButtonClick(object sender, EventArgs eventArgs)
        {
            Toast.MakeSnackbar("Some text", "OK", SnackBar_OnOkButtonClickedHandler, "OK");
        }
        private void Test_OnButtonClick(object sender, EventArgs eventArgs)
        {
            Bar();
            DConsole.WriteLine("Foo? " + _foo + " Bar");
            DConsole.WriteLine("123");

        }
        private void Bar()
        {
            _foo = true;
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
