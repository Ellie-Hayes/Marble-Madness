using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volumes : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneToLoad;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
