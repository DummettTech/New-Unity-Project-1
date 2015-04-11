using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
	public Slider level;
	public static int curlevel;


    void Awake ()
    {
        score = 0;
		curlevel = 0;

    }


    void Update ()
    {

		level.value = score;

	if (score == 100) 

		{

			score = 0;
			curlevel += 1;
			level.value = score;

		}

    }
}
