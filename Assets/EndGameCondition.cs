using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCondition : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.attachedRigidbody.velocity.y > -1)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
