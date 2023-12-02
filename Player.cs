using HarmonyLib;
using UnityEngine;

namespace LinuxMouseFix
{
    [HarmonyPatch(typeof(PLPlayer), "Update")]
    internal class Player
    {
        static float verticalRotation = 0;
        static float horizontalRotation = 0;
        static bool[] lastButtonDown = new bool[] { false, false, false, false, false };
        static bool[] buttonDown = new bool[] { false, false, false, false, false };
        static bool buttonChanged = false;
        static void Prefix(PLPlayer __instance, PLPawn ___MyPawn)
        {
            if (___MyPawn != null && ___MyPawn == PLNetworkManager.Instance.MyLocalPawn)
            {
                if (buttonChanged)
                {
                    ___MyPawn.VerticalMouseLook.RotationY = verticalRotation;
                    ___MyPawn.HorizontalMouseLook.RotationX = horizontalRotation;
                }
                verticalRotation = ___MyPawn.VerticalMouseLook.RotationY;
                horizontalRotation = ___MyPawn.HorizontalMouseLook.RotationX;

                buttonChanged = false;
                for (int i = 0; i < 5; i++)
                {
                    lastButtonDown[i] = buttonDown[i];
                    buttonDown[i] = Input.GetMouseButton(i);
                    if (buttonDown[i] != lastButtonDown[i])
                    {
                        buttonChanged = true;
                    }
                }
            }
        }
    }
}
