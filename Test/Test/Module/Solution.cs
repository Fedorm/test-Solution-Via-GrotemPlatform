using BitMobile.ClientModel3;

namespace Test
{
    public class Solution : Application
    {
        public override void OnCreate()
        {
            DB.Init();
            BusinessProcess.Init();
            DConsole.WriteLine(Translator.Translate("greeting"));
        }

        public override void OnShake()
        { DConsole.WriteLine("on shake"); }

        public override void OnRestore()
        { DConsole.WriteLine("on restore"); }

        public override void OnBackground()
        { DConsole.WriteLine("on background"); }
    }

}
