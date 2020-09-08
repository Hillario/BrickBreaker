/*
 *Manages the spawning of the ball
 *@Hillary_Chesaro
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallManager : MonoBehaviour
{
    private Vector2 ballStartPosition;
    private SpriteRenderer visualBallSpriteRenderer;
    private LineRenderer lineRenderer;
    private TextMeshPro numberBallsText;

    public GameObject bricksManager;
    public GameObject BallPrefabs;

    public int ballsNumber;
    public float tickInSecond;
    public float inpulseForce;

    private bool isGoing = false;
    private bool canSpawnNewLine = false;

    // Start is called before the first frame update
    void Start()
    {
        ballStartPosition = transform.position;
        visualBallSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        bricksManager = GameObject.Find("BrickManager");
        numberBallsText = GetComponentInChildren<TextMeshPro>();
        numberBallsText.text = ballsNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        if (Input.GetButtonUp("Fire1") && !isGoing)
        {
            StartCoroutine(startLaunchingBalls(mouseDir, mousePos));
            
            lineRenderer.SetPosition(1, transform.position);
        }

        if (isGoing || FindObjectsOfType<Ball>().Length > 0)
        {
            visualBallSpriteRenderer.enabled = false;
        }
        else
        {
            visualBallSpriteRenderer.enabled = true;
        }

        
        if (Input.GetButton("Fire1") && !isGoing)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, new Vector2(mousePos.x, mousePos.y));
        }

        if (canSpawnNewLine && FindObjectsOfType<Ball>().Length <= 0)
        {
            canSpawnNewLine = false;
            bricksManager.GetComponent<BrickManager>().spawnNewBricks();
        }
    }

    IEnumerator startLaunchingBalls(Vector3 mouseDir, Vector3 mousePos)
    {
        GameObject tempBall;

        isGoing = true;

        for (int i = 0; i < ballsNumber; i++)
        {
            tempBall = Instantiate(BallPrefabs, ballStartPosition, Quaternion.identity);
            tempBall.GetComponent<Rigidbody2D>().AddForce(mouseDir * inpulseForce, ForceMode2D.Impulse);

            
            yield return new WaitForSeconds(tickInSecond);
        }

        isGoing = false;
        canSpawnNewLine = true;

        yield return null;
    }

    public void AddBalls(int num)
    {
        ballsNumber += num;
        numberBallsText.text = ballsNumber.ToString();
    }

}
