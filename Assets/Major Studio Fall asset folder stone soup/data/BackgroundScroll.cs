using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MeshRenderer myRenderer = GetComponent<MeshRenderer> ();
		myRenderer.material.SetTextureOffset ("_MainTex", new Vector2 (Time.time/4, 0));
		
		//myRenderer.material.mainTextureOffset = new Vector2 (Time.time, 0);
		
	}
}

