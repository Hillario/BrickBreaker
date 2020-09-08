/*
 *Brick Prefab Properties
 *@Hillary_Chesaro
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Brick : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();

        lives = Random.Range(1, 30);

        textMeshPro.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            lives--;
            textMeshPro.text = lives.ToString();

            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
