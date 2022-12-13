using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale = new Vector3(0.30931f, 0.309317678f, 0.309317678f);
        Renderer slay = player.GetComponent<Renderer>();
        slay.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
