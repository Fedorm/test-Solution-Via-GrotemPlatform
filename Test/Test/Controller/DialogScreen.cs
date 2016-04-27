using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DialogScreen: Screen
    {
        private Dialog dialog;
        private EditText editText;
        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            editText = new EditText();
            editText.AutoFocus = true;

            vl.AddChild(new Button("Test Dialog.Message Success", AddNewDialog_OnClick));
            vl.AddChild(new Button("Test Dialog", TestDialog_OnClick));
            
            vl.AddChild(new Button("Back", Back_OnClick));
            vl.AddChild(editText);
        }


        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
        private void AddNewDialog_OnClick(object sender, EventArgs e)
        {
            Dialog.Message("Success");

        }
        private void TestDialog_OnClick(object sender, EventArgs e)
        {
            //Dialog.Alert("ALERT", Back_OnClick, null, "Positive", "Negative", "Neutral");
         //Dialog.Debug();
        }
    }
}