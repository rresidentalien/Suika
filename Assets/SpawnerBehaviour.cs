using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerBehaviour : MonoBehaviour
{
    bool currentlySpawned = false;
    public GameObject fruitPrefab;
    GameObject clone;
    float mouseX;
    float timer;
    int shapeTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (currentlySpawned == false)
            {
                currentlySpawned = true;
                clone = Instantiate(fruitPrefab, this.gameObject.transform.localPosition, Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().isKinematic = true; //will stay in place

                clone.tag = Random.Range(1,5).ToString();
            }

            shapeTag = int.Parse(clone.tag);
            mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            if (clone.tag == "1")
            {
                if ((mouseX > -14.3) && (mouseX < 14.3))
                {
                    clone.transform.position = new Vector3(mouseX, 23, 0);
                }
            }
            else if (clone.tag == "2")
            {
                if ((mouseX > -13.7) && (mouseX < 13.7))
                {
                    clone.transform.position = new Vector3(mouseX, 23, 0);
                }
            }
            else
            {
                if ((mouseX > -13) && (mouseX < 13))
                {
                    clone.transform.position = new Vector3(mouseX, 23, 0);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                clone.GetComponent<Rigidbody2D>().isKinematic = false;
                currentlySpawned = false;
                timer = 1;
            }
        } else 
        {
            timer -= Time.deltaTime;
        }
    }
}
