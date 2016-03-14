using System;

using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class SecondScreen : Screen
    {
        public override void OnLoading()
        {
            var vl = new VerticalLayout();
            AddChild(vl);

            var btn = new Button();
            btn.Text = "Make snapshot";
            btn.OnClick += btn_OnClick;

            vl.AddChild(btn);

            vl.AddChild(new Button("Back", back_OnClick));
            
        }

        void btn_OnClick(object sender, EventArgs e)
        {
            Guid id = Guid.NewGuid();
            String fileName = String.Format("shared/{0}", id.ToString());
            Camera.MakeSnapshot(fileName, 500,
                delegate(object sender2, EventArgs e2)
                {
                    Test.Model.Document.Photos photo = new Model.Document.Photos();
                    photo.Id = id;
                    photo.FileName = fileName;
                    photo.Save();

                    BusinessProcess.DoBack();
                }
            );
        }
        void back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }

       

    }
}
