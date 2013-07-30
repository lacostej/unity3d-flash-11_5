using UnityEngine;




public class TextureUtil
{
	//private static Logger m_Logger = LogManager.getLogger(typeof(TextureUtil), Level.Error);
	

	static public void LoadFromBytes(ref Texture2D _Tex, string UnityAssetName) {
		LoadFromBytes(ref _Tex, UnityAssetName, TextureFormat.ARGB32);
	}

	static public void LoadFromBytes(ref Texture2D _Tex, string UnityAssetName, TextureFormat _TextureFormat) {
		//m_Logger.Debug("Loading {0} into {1}", UnityAssetName, _Tex);
		TextAsset TextAssetTmp = (TextAsset) Resources.Load(UnityAssetName);
		if (TextAssetTmp == null)
		{
			Debug.LogError("Could not load texture " + UnityAssetName);
			return;
		}
		DestroyTex(ref _Tex);
		_Tex = new Texture2D(4,4,_TextureFormat,false);
		_Tex.LoadImage(TextAssetTmp.bytes);
	}
	
	static public void DestroyTex(ref Texture2D _Tex) {
		if(_Tex != null) {
			//Logger.Debug("Destroying " + _Tex);
			UnityEngine.Object.Destroy(_Tex);
			_Tex = null;
		}
	}
	
	public static float AddColWithAlpha(float _c1, float _c2, float _Alpha)
	{
		return _c1 + (_c2 - 0.5f)*_Alpha;
	}
	
	public static Texture2D CombineTexture(string _txt1, string _txt2)
	{
		Texture2D t1 = (Texture2D)Resources.Load(_txt1);
		Texture2D t2 = (Texture2D)Resources.Load(_txt2);
	
		if(t1 != null && t2 != null)
			return CombineTexture(t1, t2);
		
		return null;
	}
	
	public static Texture2D CombineTexture(Texture2D _txt1, Texture2D _txt2)
	{
		if(_txt1.width != _txt2.width && _txt1.height != _txt2.height)
			return null;
		
		Texture2D Result = new Texture2D(_txt1.width, _txt1.height);
	
		Color[] ColTab1 = _txt1.GetPixels();
		Color[] ColTab2 = _txt2.GetPixels();
		
		for(int i = 0; i < ColTab1.Length; i++)
		{
			ColTab1[i].r = AddColWithAlpha(ColTab1[i].r, ColTab2[i].r, ColTab2[i].a);
			ColTab1[i].g = AddColWithAlpha(ColTab1[i].g, ColTab2[i].g, ColTab2[i].a);
			ColTab1[i].b = AddColWithAlpha(ColTab1[i].b, ColTab2[i].b, ColTab2[i].a);
		}
		
		Result.SetPixels(ColTab1);
		Result.Apply();
		
		return Result;
	}
}
