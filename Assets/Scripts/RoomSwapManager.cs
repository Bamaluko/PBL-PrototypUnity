using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class RoomSwapManager : MonoBehaviour
{
    public static RoomSwapManager instance;
    public bool canSwap = true;
    public GameObject brightWorld;
    public GameObject darkWorld;
    public int buttonPuzzle = 0;

    public int ballsCollected = 0;

    private int turn = 0;
    public GameObject[] objectsToShow;
    public GameObject[] otherObjectsToShow;
    private bool gameLost = false;
    private float lostCounter = 0;

    public GameObject fogOfWar;
    public Transform fogOfWarPoint;

    private float roomSwapCounter = 1;
    

    private void Start()
    {
        instance = this;
        darkWorld.SetActive(true);
        darkWorld.SetActive(false);
    }

    void Update()
    {
        if (gameLost)
        {
            lostCounter += Time.deltaTime;
            if (lostCounter >= 3)
            {
                SceneManager.LoadScene("HopaScene");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && canSwap && roomSwapCounter == 1)
        {
            roomSwapCounter = .5f;
            Instantiate(fogOfWar, fogOfWarPoint.position, Quaternion.identity);
        }
        else if(roomSwapCounter != 1)
        {
            roomSwapCounter -= Time.deltaTime;
            if (roomSwapCounter <= 0)
            {
                roomSwapCounter = 1;
                brightWorld.SetActive(!brightWorld.activeSelf);
                darkWorld.SetActive(!darkWorld.activeSelf);
                if (brightWorld.activeSelf)
                {
                    turn++;
                    RoomChangeManager();
                }
            }
        }
    }

    void RoomChangeManager()
    {
        if (objectsToShow.Length >= turn)
        {
            objectsToShow[turn - 1].SetActive(true);
        }
        switch (turn)
        {
            case 4:
                otherObjectsToShow[0].SetActive(false);
                otherObjectsToShow[1].SetActive(true);
                break;
            case 6:
                otherObjectsToShow[5].SetActive(true);
                break;
            case 7:
                otherObjectsToShow[8].SetActive(true);
                break;
            case 8:
                otherObjectsToShow[1].SetActive(false);
                otherObjectsToShow[2].SetActive(true);
                break;
            case 10:
                otherObjectsToShow[6].SetActive(true);
                break;
            case 11:
                otherObjectsToShow[8].SetActive(true);
                break;
            case 12:
                otherObjectsToShow[2].SetActive(false);
                otherObjectsToShow[3].SetActive(true);
                otherObjectsToShow[7].SetActive(true);
                break;
            case 13:
                otherObjectsToShow[8].SetActive(true);
                break;
            case 14:
                otherObjectsToShow[3].SetActive(false);
                otherObjectsToShow[4].SetActive(true);
                break;
            case 16:
                otherObjectsToShow[11].SetActive(true);
                break;
            case 17:
                otherObjectsToShow[11].SetActive(false);
                otherObjectsToShow[12].SetActive(false);
                otherObjectsToShow[13].SetActive(true);
                break;
            case 18:
                
                otherObjectsToShow[4].SetActive(false);
                otherObjectsToShow[14].SetActive(true);
                otherObjectsToShow[15].SetActive(true);
                gameLost = true;
                break;
        }

    }
}
