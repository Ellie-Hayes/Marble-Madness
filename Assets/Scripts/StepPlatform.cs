using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPlatform : MonoBehaviour
{
    public bool endPlat;
    public GameObject slayObject;
    GlobalData globalData;
    bool Done;

    private void Start()
    {
        globalData = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GlobalData>();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!Done)
            {
                if (endPlat)
                {
                    globalData.turnOnGem();

                }
                else
                {
                    slayObject.SetActive(true);
                }

                Done = true;
            }

            GameObject playerspawner = GameObject.Find("Spawn Point 1");
            playerspawner.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            
        }
    }
}
