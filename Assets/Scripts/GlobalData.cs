using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public int gemsColl = 0;
    public GameObject[] gems;
    public GameObject endPlatColours; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gemsColl == gems.Length)
        {
            endPlatColours.SetActive(true);
        }
    }

    public void turnOnGem()
    {
        PaintObject paintGem = gems[gemsColl].GetComponent<PaintObject>();
        paintGem.ChangeColour();
        gemsColl++;
        Debug.Log("Paint");
    }
}
