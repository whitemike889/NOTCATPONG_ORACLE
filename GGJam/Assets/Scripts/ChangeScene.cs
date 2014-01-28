using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    public string NextScene;
    public int iCounter;
    public bool bUseCounter;
    private int InitCounter = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            if (!bUseCounter)
            {
                Application.LoadLevel(NextScene);
            }
            else
            {
                if (InitCounter > iCounter)
                {
                    Application.LoadLevel(NextScene);
                }
                else
                {
                    InitCounter++;
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}


}
