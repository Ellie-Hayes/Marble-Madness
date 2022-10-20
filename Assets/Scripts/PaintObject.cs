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
    bool doChangeColour; 
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
        if (collision.gameObject.name == "PlayerColourChanger")
        {
            /*
            mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = currentMaterials[j];
            }*/
            doChangeColour = true;
        }
    }

    private void Update()
    {
        if (doChangeColour)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;

            var mats = new Material[rend.materials.Length];

            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = currentMaterials[j];
            }

            rend.materials = mats;

        }
    }
}
