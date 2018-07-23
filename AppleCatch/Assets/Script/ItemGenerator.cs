using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject applePrefab;
    public GameObject bombPrefab;
    public GameObject gapplePrefab;
    float 
        span=1.0f,
        delta=0;
    int ratio = 2;
    float speed = -0.03f;

    public void SetParamator(float span,float speed,int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        delta+= Time.deltaTime;

        if(delta>span)
        {
            Debug.Log("OK");
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if(dice<=ratio)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else if(dice>=10)
            {
                item = Instantiate(gapplePrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = speed;
        }
	}
}
