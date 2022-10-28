using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleCont : MonoBehaviour
{
    MeshRenderer rend;
    public Material[] Materials;
    GameObject Player; 
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        var camera = Camera.main;
        var mousePosition = Input.mousePosition;
        var ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane));
        if (Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            Debug.Log(hit.point);
            StartRipple(hit.point);
            
        }
    }

    void StartRipple(Vector3 center)//change to collider https://docs.unity3d.com/ScriptReference/Collider.ClosestPoint.html
    {
        Debug.Log("Started");
        for (int i = 0; i < rend.materials.Length; i++)
        {
            Debug.Log("StartedForLoop");
            
            for (int j = 0; j < rend.materials.Length; j++)
            {
                Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials;
                currentlyAssignedMaterials[j] = Materials[j];
                currentlyAssignedMaterials[j].SetVector("_RippleCenter", center);
                currentlyAssignedMaterials[j].SetFloat("_RippleStartTime", Time.time);
                GetComponent<Renderer>().materials = currentlyAssignedMaterials;
            }
            
        }
        
    }

}
