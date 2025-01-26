using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}
