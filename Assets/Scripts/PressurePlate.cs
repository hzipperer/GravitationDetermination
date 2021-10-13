using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    SpriteRenderer plateRenderer;

    // Start is called before the first frame update
    void Start()
    {
        plateRenderer = GetComponent<SpriteRenderer>();
        plateRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        plateRenderer.color = Color.green;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        plateRenderer.color = Color.red;
    }
}
