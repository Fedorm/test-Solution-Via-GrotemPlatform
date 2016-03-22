using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DockLayoutScreen : Screen
    {
        private DockLayout dl;
        private TextView textView;

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {
            //var vl = new VerticalLayout();
            //AddChild(vl);

            dl = new DockLayout();
            dl.Id = "ID Of DockLayout";
            dl.OnClick += dl_OnClick;
            dl.AddChild(new Button("Back", Back_OnClick));
            AddChild(dl);
            //vl.AddChild(new Button("Change Visibility Of DL", ChangeVisibilityOfDL_OnClick));
            //vl.AddChild(new Button("Back", Back_OnClick));
            //vl.AddChild(dl);

            //dl.AddChild(new TextView("ALLOHA DL"));
            //dl.AddChild(new TextView("ALLOHA DL2"));

            //отображается только две текствьюхи

            //dl.AddChild(new TextView("ALLOHA DL3"));
            //dl.AddChild(new TextView("ALLOHA DL4"));
        }

        private void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

        private void dl_OnClick(object sender, EventArgs e)
        {
            var dl = (DockLayout) sender;
            dl.CssClass = "DockLayout2";
            dl.Refresh();
        }

        private void ChangeVisibilityOfDL_OnClick(object sender, EventArgs e)
        {
            if (dl.Visible)
            {
                dl.Visible = false;
                DConsole.WriteLine(string.Format(dl.Id));
            }
            else if (dl.Visible == false)
            {
                dl.Visible = true;
            }
        }
    }
}