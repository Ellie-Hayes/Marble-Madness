using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1 Forest");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2 City");
    }
}
