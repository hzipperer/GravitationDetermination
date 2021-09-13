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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        plateRenderer.color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        plateRenderer.color = Color.red;
    }
}
