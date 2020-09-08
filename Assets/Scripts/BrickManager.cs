/*
 *Manages the spawning of the bricks
 *@Hillary_Chesaro
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public GameObject powerUpBallPrefab;

    private Vector2 brickSpawnStartPosition;
    private Vector2 brickSpawnCurrentPositon;

    private List<GameObject> bricks = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        brickSpawnStartPosition = GameObject.Find("SpawnPosition").transform.position;
        spawnNewBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnNewBricks()
    {
        brickSpawnCurrentPositon = brickSpawnStartPosition;

        
        if (bricks.Count > 0)
        {
            foreach (GameObject block in bricks)
            {
                if (block != null)
                    block.transform.position -= new Vector3(0, 0.9f, 0);
            }

            
            bricks.RemoveAll(block => block == null);
        }

        for (int i = 0; i < 5; i++)
        {
            int rndNum = Random.Range(0, 3);

            switch (rndNum)
            {
                case 1:
                    bricks.Add(Instantiate(brickPrefab, brickSpawnCurrentPositon, Quaternion.identity));
                    break;
                case 2:
                    bricks.Add(Instantiate(powerUpBallPrefab, brickSpawnCurrentPositon, Quaternion.identity));
                    break;
                case 3:
                    break;
            }

            brickSpawnCurrentPositon.x += 0.9f;
        }
    }
}
