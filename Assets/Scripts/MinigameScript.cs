using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameScript : MonoBehaviour
{
    public string sceneToLoad;

    private void OnMouseDown()
    {
        if (RoomSwapManager.instance.ballsCollected >= 3)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
