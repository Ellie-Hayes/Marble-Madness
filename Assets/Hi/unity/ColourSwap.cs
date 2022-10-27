using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrtwpns.Mixbox
{
    public class ColourSwap : MonoBehaviour
    {
        [Tooltip("Material the ball will be swapped to")]
        public Color SwitchColour;
        public Material targetMaterial;

        void Start()
        {
            gameObject.transform.Find("ColourIndicator").GetComponentInChildren<Renderer>().material.color = SwitchColour;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerBallColour playerBallColour = other.GetComponent<PlayerBallColour>();
                playerBallColour.ColourNew(SwitchColour);
            }
        }
    }
}
