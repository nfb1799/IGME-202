using UnityEngine;
using UnityEngine.UI; // Note this new line is needed for UI
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    CollisionDetector collisionDetector;
    public List<GameObject> rocks;
    public List<GameObject> antirocks;
    public GameObject rocket;
    GameObject antirock;
    GameObject rock;

    int playerScore = 0;

    bool rockOut;
    bool sphereTest = false;

    public void Start()
    {
        collisionDetector = gameObject.GetComponent<CollisionDetector>();
        rocks = new List<GameObject>();
        antirocks = new List<GameObject>();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            sphereTest = !sphereTest;

        //check to see whether any rock has rolled onto the rocket
        foreach (GameObject rck in rocks)
        {
            if (collisionDetector.AABBTest(rocket, rck))
                PlayerDied();
            if (rck.transform.position.y < -8)
            {
                RemoveRockFromList(rck);
                Destroy(rck);
            }
        }
        foreach (GameObject antirck in antirocks)
        {
            if (antirck.transform.position.y > 8)
            {
                RemoveAntiRockFromList(antirck);
                Destroy(antirck);
            }
        }
            rockOut = false;

        foreach (GameObject antirck in antirocks)
        {
            if (antirck.transform.position.y > 8)
            {
                RemoveAntiRockFromList(antirck);
                Destroy(antirck);
                break;
            }
            foreach (GameObject rck in rocks)
            {
                if (!sphereTest)
                {
                    if (collisionDetector.AABBTest(antirck, rck))
                    {
                        //Debug.Log("antirock hit rock!");
                        rockOut = true;
                        antirock = antirck;
                        rock = rck;
                        break;
                    }
                }
                else
                {
                    if (collisionDetector.BoundingSphereTest(antirck, rck))
                    {
                        //Debug.Log("antirock hit rock!");
                        rockOut = true;
                        antirock = antirck;
                        rock = rck;
                        break;
                    }
                }
            }

            if (rockOut)
                break;
        }

        if (rockOut)
        {
            RemoveRockFromList(rock);
            RemoveAntiRockFromList(antirock);
            Destroy(rock);
            Destroy(antirock);
            AddScore();
        }

    }

    public void AddRockToList(GameObject rock)
    {
        rocks.Add(rock);
    }

    public bool RemoveRockFromList(GameObject rock)
    {
        return rocks.Remove(rock);
    }

    public void AddAntiRockToList(GameObject antirock)
    {
        antirocks.Add(antirock);
    }

    public bool RemoveAntiRockFromList(GameObject antirock)
    {
        return antirocks.Remove(antirock);
    }


    public void AddScore()
    {
        playerScore++;
        //This converts the score (a number) into a string
        scoreText.text = playerScore.ToString();
    }

    public void PlayerDied()
    {
        gameOverText.enabled = true;

        // This freezes the game
        Time.timeScale = 0;
    }
}
