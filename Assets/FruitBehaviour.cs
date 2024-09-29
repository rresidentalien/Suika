using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    int shapeTag;
    public Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shapeTag = int.Parse(this.gameObject.tag);

        this.gameObject.transform.localScale = new Vector3(1.5f*shapeTag, 1.5f*shapeTag, 1);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = images[shapeTag-1];
    }

    //check if collision tag is equal to current tag, if so, convert current tag to integer and increment and then convert back
    //to string and assign to the tag
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {
            shapeTag = int.Parse(this.gameObject.tag);
            ++shapeTag;
            this.gameObject.tag = shapeTag.ToString();
            Destroy(collision.gameObject);
        }
    }
}
