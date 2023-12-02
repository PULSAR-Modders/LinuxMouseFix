using PulsarModLoader;

namespace LinuxMouseFix
{
    public class Mod : PulsarMod
    {
        public override string Version => "0.0.0";

        public override string Author => "18107";

        public override string ShortDescription => "Fixes the mouse movement on Linux";

        public override string Name => "Linux Mouse Fix";

        public override string ModID => "id107.linuxmousefix";

        public override string HarmonyIdentifier()
        {
            return "id107.linuxmousefix";
        }
    }
}
