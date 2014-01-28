using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class OracleReader : MonoBehaviour {

    enum OracleKey {Fate,Love,Number}
	List<string> LstPhraceFate = new List<string>();
	List<string> LstPhraceLove = new List<string>();
    public float fadeDuration = 3.0f;
    string sActualPhrace = string.Empty;
    GUIStyle TxtStyle = new GUIStyle();
    float Fader = 255f;
    float Ammount = (255f * 3f) / 30f;
    

    ///FOR TEST ////////////////////
    ///Contador
    int iTipo = 0;
    ////////////////////////////////

	// Use this for initialization
	void Start () 
    {
        LstPhraceFate = ReadFile(@"Assets\Resources\TextFiles\Fate.txt");
        Debug.Log("Fate Loaded");
        LstPhraceLove = ReadFile(@"Assets\Resources\TextFiles\Love.txt");
        Debug.Log("Love Loaded");
        
        TxtStyle.fontSize = 36;
        TxtStyle.normal.textColor = Color.red;

       
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            sActualPhrace = string.Format("{0}\n{1}\n{2}", getOracleCat(OracleKey.Fate),getOracleCat(OracleKey.Love),getOracleCat(OracleKey.Number));

            GameObject Prof = GameObject.Find("ProfecyTxt");
            Prof.guiText.text = sActualPhrace;
            StartCoroutine(StartFading(Prof));

            Debug.Log(sActualPhrace);
        }
	
	}

    string getOracleCat(OracleKey OK)
    {
        string sOracle = string.Empty;
        int FL = 0;
        try
        {
            switch (OK)
            {
                case OracleKey.Fate:
                    FL = LstPhraceFate.Count;
                    sOracle = LstPhraceFate[Convert.ToInt32(UnityEngine.Random.Range(0, FL - 1))];
                    break;
                case OracleKey.Love:
                    FL = LstPhraceLove.Count;
                    sOracle = LstPhraceLove[Convert.ToInt32(UnityEngine.Random.Range(0, FL - 1))];
                    break;
                case OracleKey.Number:
                    sOracle = "Tus números de la suerte son: ";
                    for (int i = 0; i < 6; i++)
                    {
                        sOracle += Convert.ToInt32(UnityEngine.Random.Range(0f, 99f)).ToString() + " ";
                    }
                    break;
            }

        }
        catch (Exception ex)
        {
            Debug.Log(string.Format("{0}\n", ex.Message));
        }

        return sOracle;

    }

	List<string> ReadFile(string fileName) 
    {
        List<string> LstFraces = new List<string>();

		try
		{
			string line;

			StreamReader theReader = new StreamReader(fileName);
			
			using (theReader)
			{
				do
				{
					line = theReader.ReadLine();
                    LstFraces.Add(line);
				}
				while (line != null);
				
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
                return LstFraces;
			}
		}
		catch (Exception ex)
		{
            Debug.Log(string.Format("{0}\n", ex.Message));
			return LstFraces;
		}
	
	}

    private IEnumerator StartFading(GameObject GOTxt)
    {
        yield return StartCoroutine(Fade(1.0f, 0.0f, fadeDuration,GOTxt));
    }

    private IEnumerator Fade(float startLevel, float endLevel, float time, GameObject GOTxt)
    {

        float speed = 1.0f / time;
        for (float t = 0.0f; t < 1.0; t += Time.deltaTime * speed)
        {
            float a = Mathf.Lerp(endLevel, startLevel,  t);
            GOTxt.guiText.font.material.color = new Color(GOTxt.guiText.font.material.color.r, GOTxt.guiText.font.material.color.g, GOTxt.guiText.font.material.color.b, a);

            yield return 0;
        }
    }

}


