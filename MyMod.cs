#region Usings
// C#
using System;
using System.Reflection;

// Unity
using UnityEngine;
using TMPro;

// Quantum Console
using QFSW.QC;

// HarmonyX
using HarmonyLib;
#endregion

namespace MyMod
{
  #region Custom Quantum Console command
  // Add a command to Quantum Console (https://www.qfsw.co.uk/docs/QC/articles/quickstart/quickstart.html#adding-commands)
  static class AddCommand
  {
    [Command("my-mod", "Custom command from example mod")]
    public static void ExampleCommand()
    {
      Debug.Log("Hello from My Mod!");
    }
  }
  #endregion

  #region Patching example in private field
  // Patch a method using Harmony (https://harmony.pardeike.net/articles/basics.html)
  // You should use nameof(Method) whenever possible,
  //  but since GetDailyMessage.GetMessage is private
  //  we need to use a string
  [HarmonyPatch(typeof(GetDailyMessage))]
  class Patch
  {
    [HarmonyPrefix]
    [HarmonyPatch("GetMessage")]
    static bool Prefix(GetDailyMessage __instance)
    {
      Debug.Log("Changing Daily Message");

      // Use reflection to access and modify a private field/class/property/etc.
      Type GetDailyMessageType = __instance.GetType();
      if (GetDailyMessageType == null)
      {
        Debug.LogError("Unable to find type of GetDailyMessage");
        return true;
      }

      FieldInfo messageFieldInfo = GetDailyMessageType.GetField("Message", BindingFlags.NonPublic | BindingFlags.Instance);
      if (messageFieldInfo == null)
      {
        Debug.LogError("Unable to find Message field");
        return true;
      }

      TextMeshProUGUI tmp = (TextMeshProUGUI)messageFieldInfo.GetValue(__instance);
      tmp.text = "Hello from My Mod!";

      // Don't run original and other prefix methods
      return false;
    }
  }
  #endregion
}