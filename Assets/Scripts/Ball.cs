/*
 *Determines the ball's existence if it is visible
 *@Hillary_Chesaro
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spriteRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
