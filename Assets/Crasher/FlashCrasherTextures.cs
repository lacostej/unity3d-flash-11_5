using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_FLASH
using UnityEngine.Flash;
#endif

[RequireComponent(typeof(GUIText))]
public class FlashCrasherTextures : MonoBehaviour {
	public List<GameObject> objects = new List<GameObject>();

	void Awake() {

	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 10; i++) {
			GameObject go = new GameObject("GO_" + (objects.Count));
            GUITexture Text = go.AddComponent<GUITexture>();
            Texture2D Tex2D = null;
			TextureUtil.LoadFromBytes(ref Tex2D, "fondA");
			Text.texture = Tex2D;
			objects.Add(go);
		}
	}

	void OnGUI() {
        gameObject.guiText.text = "List contains " + objects.Count.ToString() + " elements";
	}
}
