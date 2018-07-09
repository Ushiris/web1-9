using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    GameObject timerText;
    GameObject pointText;
    float time = 60.0f;
    int point = 0;

    public void GetApple()
    {
        point += 100;
    }

    public void GetBomb()
    {
        point /= 2;
    }

	// Use this for initialization
	void Start ()
    {
        timerText = GameObject.Find("Time");
        pointText = GameObject.Find("Point");
    }
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        timerText.GetComponent<Text>().text = time.ToString("F1");
        pointText.GetComponent<Text>().text = point.ToString() + " point";
	}
}
