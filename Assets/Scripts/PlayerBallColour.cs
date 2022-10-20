using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallColour : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color.Lerp(Color.blue, Color.red, 0.5f);

    }
}
