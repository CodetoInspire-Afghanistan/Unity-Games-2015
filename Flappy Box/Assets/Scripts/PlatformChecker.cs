using UnityEngine;
using System.Collections;

/// <summary>
/// Platform checker.
/// [check the current platform]
/// </summary>
public class PlatformChecker : MonoBehaviour
{
		public static bool IsAndroid ()
		{
				return Application.platform == RuntimePlatform.Android;
		}

		public static bool IsIOS ()
		{
				return Application.platform == RuntimePlatform.IPhonePlayer;
		}

		public static bool IsWindows ()
		{
				return Application.platform == RuntimePlatform.WindowsPlayer;
		}

		public static bool isWebPlayer ()
		{
				return Application.isWebPlayer;
		}

		public static bool isFlash ()
		{
				return Application.platform == RuntimePlatform.FlashPlayer;
		}

		public static bool IsWindowsEditor ()
		{
				return Application.platform == RuntimePlatform.WindowsEditor;
		}
}