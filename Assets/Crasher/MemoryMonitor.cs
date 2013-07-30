using UnityEngine;
using System.Collections;

#if UNITY_FLASH && !UNITY_EDITOR
using UnityEngine.Flash;
#endif
 
[RequireComponent(typeof(GUIText))]
public class MemoryMonitor : MonoBehaviour {
	public float frequency = 0.5f;
 
	public int FramesPerSec { get; protected set; }
 
	private void Start() {
		//if (PrefMgr.m_ProdVersion == false)
			StartCoroutine(DumpMemory());
	}
 
	/*
	 * EVENT: FPS
	 */
	private IEnumerator DumpMemory() {
		for(;;){
			yield return new WaitForSeconds(frequency);
			string s = "";
#if UNITY_FLASH && !UNITY_EDITOR
			ActionScript.Import("com.unity.UnityNative");
			ActionScript.Statement("this._s___0 = MemoryReporter.ReportMem();");
#else
			s = "MEM: " + System.GC.GetTotalMemory(false);					
#endif
			gameObject.guiText.text = s;
		}
	}
}
