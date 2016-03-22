using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class ButtonScreen : Screen
    {
        private Button _cssButton;
        private Button _invisibleButton;
        private VerticalLayout _vl;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            _vl = new VerticalLayout();
            AddChild(_vl);

            _invisibleButton = new Button {Text = "HIDE ME", Visible = false};
            _invisibleButton.OnClick += Visible_OnClick;

            _cssButton = new Button();
            _cssButton.CssClass = "CssButton";
            _cssButton.Text = "CssButton";
            _cssButton.OnClick += ChangeCssAndText_OnClick;
            _cssButton.Id = "Id Of Invisible Button";

            _vl.AddChild(new Button("Unhide Button", Visible_OnClick));

            _vl.AddChild(_invisibleButton);
            _vl.AddChild(_cssButton);
            _vl.AddChild(new Button("Back", Back_OnClick));
        }

        private void Visible_OnClick(object sender, EventArgs e)
        {
            if (_invisibleButton.Visible)
            {
                _invisibleButton.Visible = false;
                DConsole.WriteLine(string.Format(_cssButton.Id));
            }
            else if (_invisibleButton.Visible == false)
            {
                _invisibleButton.Visible = true;
            }
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void ChangeCssAndText_OnClick(object sender, EventArgs e)
        {
            if (_cssButton.CssClass == "CssButton")
            {
                _cssButton.CssClass = "ChangeCssButton";
                _cssButton.Text = "ChangeCss";
                _cssButton.Refresh();
            }
            else if (_cssButton.CssClass == "ChangeCssButton")
            {
                _cssButton.CssClass = "CssButton";
                _cssButton.Text = "CssButton";
                _cssButton.Refresh();
            }
        }
    }
}