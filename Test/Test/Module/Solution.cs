using System;
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
                PushNotification.InitializePushService("http://192.168.0.152/bitmobile/synchro3",
                    "8d3e3420-f723-11e5-80fd-902b3416d383", "srm");
            }
            catch (Exception)
            {
                DConsole.WriteLine("SOME EXCEPTION");
            }
        }

        public override void OnPushMessage(string message)
        {
            Toast.MakeToast($"NEW MESSAGE = {message}");
            DConsole.WriteLine($"NEW MESSAGE = {message}");
        }

        public override void OnShake()
        {
            DConsole.WriteLine("on shake");
        }

        public override void OnRestore()
        {
            DConsole.WriteLine("on restore");
        }

        public override void OnBackground()
        {
            DConsole.WriteLine("on background");
        }
    }
}