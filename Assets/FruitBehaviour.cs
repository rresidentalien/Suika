using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    int fruitTag;
    public Color[] colours;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fruitTag = int.Parse(this.gameObject.tag);

        this.gameObject.transform.localScale = new Vector3(1.25f*fruitTag, 1.25f*fruitTag, 1);
        this.gameObject.GetComponent<SpriteRenderer>().color = colours[fruitTag-1];
        Debug.Log(fruitTag);
    }

    //check if collision tag is equal to current tag, if so, convert current tag to integer and increment and then convert back
    //to string and assign to the tag
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {
            fruitTag = int.Parse(this.gameObject.tag);
            ++fruitTag;
            this.gameObject.tag = fruitTag.ToString();
            Destroy(collision.gameObject);
        }
    }
}
