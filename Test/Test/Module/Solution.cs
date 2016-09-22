using System;
using System.Text;
using BitMobile.ClientModel3;
using ClientModel3.MD;

namespace Test
{
    public class Solution : Application
    {
        public override void OnCreate()
        {

           
            BusinessProcess.Init();
            DConsole.WriteLine(Translator.Translate("greeting"));
            try
            {
                PushNotification.InitializePushService("http://192.168.0.152/bitmobile", "15f3904b-942b-11e5-bb64-f8a963e4bf15", "sr");
            }
            catch (Exception)
            {
                
               DConsole.WriteLine("SOME EXCEPTION");
            }
            
        }
        public override void OnPushMessage(string message)
        {
            DConsole.WriteLine($"NEW MESSAGE = {message}");
        }
        public override void OnShake()
        { DConsole.WriteLine("on shake"); }

        public override void OnRestore()
        { DConsole.WriteLine("on restore"); }

        public override void OnBackground()
        { DConsole.WriteLine("on background"); }
    }

}
