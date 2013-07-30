using UnityEngine;
#if UNITY_FLASH && !UNITY_EDITOR
using UnityEngine.Flash;
#endif
using System;

public class ActionScriptInit : MonoBehaviour {
	/*
#if UNITY_FLASH && !UNITY_EDITOR
	void Start () {
		Debug.Log("Initializing addon");
	    ActionScript.Import("addon.Initializer");
		ActionScript.Expression<Void>("addon.Initializer.Init({0})", true);
		Debug.Log("Initialized addon");
	}
#endif
*/
}
