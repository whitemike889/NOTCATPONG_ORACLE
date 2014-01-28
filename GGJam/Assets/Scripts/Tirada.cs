using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Tirada : MonoBehaviour {
    public GameObject goCarta1;
    public GameObject goCarta2;
    public GameObject goCarta3;

    List<string> LstPast = new List<string>();
    List<string> LstPresent = new List<string>();
    List<string> LstFuture = new List<string>();
    Texture2D PastSprite;
	// Use this for initialization
	void Start () {
        LstPast = ReadFile("Sujeto");
        LstPresent = ReadFile("Verbo");
        LstFuture = ReadFile("Sujeto");

        int RNum = Convert.ToInt32(UnityEngine.Random.Range(0, LstPast.Count - 1));
        PastSprite = Resources.Load(@"Images\Cartas\" + LstPast[RNum], typeof(Texture)) as Texture2D;
        Sprite PresentSprite = Resources.Load(LstPresent[RNum], typeof(Sprite)) as Sprite;
        Sprite FutureSprite = Resources.Load(LstFuture[RNum], typeof(Sprite)) as Sprite;

        //goCarta1 = PastSprite;
        //goCarta2 = PresentSprite;
        //goCarta3 = FutureSprite;

	}
	
	// Update is called once per frame
	void Update () {
        //Sprite.Create(PastSprite, new Rect(0f, 0f, 255f, 255f), new Vector2(100f, 100f));
	
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
}
