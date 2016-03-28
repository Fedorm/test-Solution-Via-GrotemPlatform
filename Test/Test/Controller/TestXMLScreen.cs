using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestXMLScreen : Screen
    {
        private readonly Button _textButton = null; //this variable will be assigned via screen xml template
        private readonly Button _visibleButton = null; //this variable will be assigned via screen xml template

        public override void OnLoading()
        {
            ((Button)GetControl("_textButton", true)).OnClick += ChangeText_OnClick;
            ((Button)GetControl("_visibleButton", true)).OnClick += ChangeVisibility_OnClick;
            ((Button)GetControl("_changeVisibilityButton", true)).OnClick += ChangeVisibility_OnClick;
            
        }


        private void ChangeText_OnClick(object sender, EventArgs e)
        {
            // можно в onLoading убрать инициализацию и менять текст таким образом
            //((Button) sender).Text = "TEST"; 


            if (_textButton.Text == "TextButton")
            {
                _textButton.Text = "Change Text Of TextButton";

            }
            else if (_textButton.Text == "Change Text Of TextButton")
            {
                _textButton.Text = "TextButton";
            }
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ExitButton_OnClick(object sender, EventArgs e)
        {
            Application.Terminate();
        }

        private void ChangeVisibility_OnClick(object sender, EventArgs e)
        {
            if (_visibleButton.Visible)
            {
                _visibleButton.Visible = false;
            }
            else if (_visibleButton.Visible == false)
            {
                _visibleButton.Visible = true;
            }

        }

    }
}