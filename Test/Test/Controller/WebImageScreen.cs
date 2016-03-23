using System;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class WebImageScreen : Screen
    {
        private WebImage _webImage;

        public override void OnLoading()
        {
            Initialize();
        }

        void Initialize()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            _webImage=new WebImage();

            vl.AddChild(_webImage);
            vl.AddChild(new Button("Back", Back_OnClick));
        }


        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

    }
}