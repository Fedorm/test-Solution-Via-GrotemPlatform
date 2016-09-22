using System;
using System.Text;
using BitMobile.ClientModel3;
using BitMobile.ClientModel3.UI;

namespace Test
{
    public class TestBugsScreen : Screen
    {
        VerticalLayout vl;
        public Database db;
      
      
        public override void OnLoading()
        {
       
            Initialize();
            
        }
        void Back_OnClick(object sender, EventArgs e)
        {
            BusinessProcess.DoBack();
        }
        private void Initialize()
        {
          vl = new VerticalLayout();
            AddChild(vl);


            new T().Start();
            new T().Start();



            vl.AddChild(new Button("Back", Back_OnClick));
    





        }

        internal class T : Thread
        {
            public override void Execute()
            {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    DConsole.WriteLine($"i = {i}");
                    Sleep(1000);
                }
            }


      void Back_OnClick(object sender, EventArgs e)
            {
                BusinessProcess.DoBack();
            }

        }

    }
}
