using UnityEngine;
using System.Collections;

public class UniversalClass  {

	public static GameObject CurrentPoint, PreviousPoint,CurrentPointCP, PreviousPointCP;
	public static  GameObject CurrentButton, PreviousButton;

	public static GameObject Current_SP_gameObject,Previous_SP_gameObject;
	public static GameObject Current_CP_gameObject,Previous_CP_gameObject;
	public static bool IsDictionaryEnabled;
	public static bool IsLanguageClicked;

	public static bool SeedChanged;
	public static FontStyle font;

	public static string TrnsactionID;
	public static string BaseUrl = "https://api.beyondbiomag.io";
	public static bool SubScriptionValid = false;
	//public static bool SubScriptionPaneEnabled = false;
	public static bool UIPanelEnabled = false;
	public static bool isRegistered= false;
	public static bool NoInternetConnection = false;

}
