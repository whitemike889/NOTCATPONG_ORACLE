using UnityEngine;
using System.Collections;

public class path : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("mypath"), "time", 12f, "loopType", "pingPong"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
