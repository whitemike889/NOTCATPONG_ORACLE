using UnityEngine;
using System.Collections;

public class path3 : MonoBehaviour {

	// Use this for initialization
	void Start () {

        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("mypath3"), "time", 5f, "loopType", "pingPong"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
