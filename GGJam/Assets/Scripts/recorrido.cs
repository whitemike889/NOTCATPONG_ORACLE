using UnityEngine;
using System.Collections;

public class recorrido : MonoBehaviour {
    public float iTtime = 7f;
    public string sLoopType = "pingPong";
    public string siTweenPathName = "path";

	// Use this for initialization
	void Start () {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath(siTweenPathName), "time", iTtime, "loopType", sLoopType));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
