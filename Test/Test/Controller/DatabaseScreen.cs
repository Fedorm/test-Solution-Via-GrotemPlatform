using System;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class DatabaseScreen : Screen
    {
     

        public override void OnLoading()
        {
            Initialize();
        }

        private void Initialize()
        {

        }

        void BackButton_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
    }
}