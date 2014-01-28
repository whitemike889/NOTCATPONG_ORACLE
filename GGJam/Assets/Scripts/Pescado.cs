using UnityEngine;
using System.Collections;

public class Pescado : MonoBehaviour {
	public int x = 0;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (x == 1) {
			anim.SetTrigger ("Explosion");
			x = 0;
		} 
	}
}
