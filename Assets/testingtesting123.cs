using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingtesting123 : MonoBehaviour
{
    public Color colourSet; 
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colourSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
