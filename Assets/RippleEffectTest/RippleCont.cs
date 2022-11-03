using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleCont : MonoBehaviour
{
    private MaterialPropertyBlock materialBlock;
    MeshRenderer rend;
    public Material[] Materials;
    GameObject Player;
    bool hit = false;

    public Material whiteMat;
    public Material[] currentMaterials;

    // Start is called before the first frame update
    void Start()
    {
        materialBlock = new MaterialPropertyBlock();
        rend = GetComponent<MeshRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");

        //materialBlock.SetFloat("_CanStart", hit ? 1f : 0f);
        //rend.SetPropertyBlock(materialBlock);

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

    private void OnTriggerEnter(Collider other)
    {
        if (!hit)
        {
            if (other.gameObject.tag == "PlayerChecker")
            {
                Debug.Log("Hit!");
                var collider = GetComponent<Collider>();

                Vector3 closestPoint = collider.ClosestPoint(Player.transform.position);
                StartRipple(closestPoint);
                hit = true;
            }
        }
       
    }
   

    void StartRipple(Vector3 center)//change to collider https://docs.unity3d.com/ScriptReference/Collider.ClosestPoint.html
    {
        Debug.Log("Started");

        var mats = new Material[rend.materials.Length];

        for (var j = 0; j < rend.materials.Length; j++)
        {
            mats[j] = currentMaterials[j];
        }

        rend.materials = mats;

        //Material mat = GetComponent<Renderer>().material;
        float rippleSpeed = 2;
        float distanceRipple = Vector3.Distance(Player.transform.position, center);
        float AdditionalTime = distanceRipple / rippleSpeed;

        float hie = AdditionalTime + Time.time;
        materialBlock.SetFloat("_CanStart", hit ? 1f : 0f);
        materialBlock.SetVector("_RippleCenter", center);
        materialBlock.SetFloat("_RippleStartTime", Time.time);
        
        rend.SetPropertyBlock(materialBlock);
        /*
        for (int i = 0; i < rend.materials.Length; i++)
        {
            Debug.Log("StartedForLoop");
            Material mat = GetComponent<Renderer>().material;
            mat.SetVector("_RippleCenter", center);
            mat.SetFloat("_RippleStartTime", Time.time);
            /*
            for (int j = 0; j < rend.materials.Length; j++)
            {
                Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials;
                currentlyAssignedMaterials[j] = Materials[j];
                currentlyAssignedMaterials[j].SetVector("_RippleCenter", center);
                currentlyAssignedMaterials[j].SetFloat("_RippleStartTime", Time.time);
                GetComponent<Renderer>().materials = currentlyAssignedMaterials;
            }
            */
        //}

    }

}
