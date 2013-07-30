using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_FLASH
using UnityEngine.Flash;
#endif

[RequireComponent(typeof(GUIText))]
public class FlashCrasher : MonoBehaviour {
	List<string> strings = new List<string>();

	void Awake() {

	}

	// Use this for initialization
	void Start () {
/*
#if UNITY_FLASH 
//&& !UNITY_EDITOR
		Debug.Log("Crashing...");
		ActionScript.Statement("throw new Error(\"Something went wrong\");");
#endif		
*/
	}
	
	// Update is called once per frame
	void Update () {
		string s = StringUtils.RandomString(1000);
		for (int i = 0; i < 10000; i++) {
			strings.Add(s + strings.Count);
		}
	}

	void OnGUI() {
        gameObject.guiText.text = "List contains " + strings.Count.ToString() + " elements";
	}
}
