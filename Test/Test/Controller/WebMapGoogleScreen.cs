using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebMapGoogleScreen : Screen
    {
        public override void OnLoading()
        {
            Initialize();
        }

        void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            vl.AddChild(new Button("Back", Back_OnClick));
        }


        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

    }
}