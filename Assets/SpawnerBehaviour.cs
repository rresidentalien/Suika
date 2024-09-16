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

            mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            if (mouseX > -13 && mouseX < 13)
            {
                clone.transform.position = new Vector3(mouseX, 23, 0);
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
