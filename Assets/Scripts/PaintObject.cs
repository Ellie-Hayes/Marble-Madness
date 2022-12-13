using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintObject : MonoBehaviour
{
    public Material whiteMat;
    Renderer rend;
    public Material[] currentMaterials;
    float duration = 2.0f;
    //Material[] mats; 
    bool ChangedColour;
    public bool gem;
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        currentMaterials = new Material[rend.materials.Length];
        
        for (int i = 0; i < rend.materials.Length; i++)
        {
            currentMaterials[i] = rend.materials[i];
        }

        var mats = new Material[rend.materials.Length];
        for (var j = 0; j < rend.materials.Length; j++)
        {
            mats[j] = whiteMat;
        }
        rend.materials = mats;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerChecker" && !ChangedColour && !gem)
        {
            /*
            mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = currentMaterials[j];
            }*/
            ChangeColour();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerChecker" && !ChangedColour && !gem)
        {
            ChangeColour();
            
        }
    }

    public void ChangeColour()
    {
        var mats = new Material[rend.materials.Length];

        for (var j = 0; j < rend.materials.Length; j++)
        {
            mats[j] = currentMaterials[j];
        }

        rend.materials = mats;
        ChangedColour = true;
    }

    private void Update()
    {
       
    }

}
