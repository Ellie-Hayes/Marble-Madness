using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintObject : MonoBehaviour
{
    public Material whiteMat;
    Renderer rend;
    public Material[] currentMaterials;
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        currentMaterials = new Material[rend.materials.Length];

        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.materials[i] = whiteMat;
            currentMaterials[i] = rend.materials[i];

            //whiteMat = rend.materials[i];
        }


        //rend.material = whiteMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
