using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;
    int basePoint = 100;

    public void GetApple()
    {
        point += basePoint;
    }

    public void GetBomb()
    {
        point /= 2;
    }

    public void GetGapple()
    {
        basePoint *= 3;
    }

	// Use this for initialization
	void Start ()
    {
        generator = GameObject.Find("ItemGenerator");
        timerText = GameObject.Find("Time");
        pointText = GameObject.Find("Point");
    }
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            generator.GetComponent<ItemGenerator>().SetParamator(10000.0f, 0, 0);
            SceneManager.LoadScene("Title");
        }
        else if (0 <= time && time < 5)
        {
            generator.GetComponent<ItemGenerator>().SetParamator(0.9f, -0.04f, 3);
        }
        else if (5 <= time && time < 10)
        {
            generator.GetComponent<ItemGenerator>().SetParamator(0.4f, -0.06f, 6);
        }
        else if (10 <= time && time < 20)
        {
            generator.GetComponent<ItemGenerator>().SetParamator(0.7f, -0.04f, 4);
        }
        else if (20 <= time && time < 30)
        {
            generator.GetComponent<ItemGenerator>().SetParamator(1.0f, -0.03f, 2);
        }

        timerText.GetComponent<Text>().text = time.ToString("F1");
        pointText.GetComponent<Text>().text = point.ToString() + " point";
	}
}
