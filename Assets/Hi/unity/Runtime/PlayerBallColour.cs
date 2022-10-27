using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrtwpns.Mixbox
{
    public class PlayerBallColour : MonoBehaviour
    {
        public Color StartColor;
        public Color EndColor;
        public float time;
        bool goingForward;
        bool isCycling;
        Material myMaterial;


        public Color NewColor;
        private void Awake()
        {
            goingForward = true;
            isCycling = false;
            myMaterial = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            if (!isCycling)
            {
                if (goingForward)
                    StartCoroutine(CycleMaterial(StartColor, EndColor, time, myMaterial));
            }
        }

        public void ColourNew(Color takenColour)
        {
            Color currentColor = Mixbox.Lerp(takenColour, EndColor, 10f);
            myMaterial.color = currentColor;

            //EndColor = NewColor;
            //goingForward = true;

        }

        IEnumerator CycleMaterial(Color startColor, Color endColor, float cycleTime, Material mat)
        {
            isCycling = true;
            float currentTime = 0;
            while (currentTime < cycleTime)
            {
                currentTime += Time.deltaTime;
                float t = currentTime / cycleTime;
                Color currentColor = Color.Lerp(startColor, endColor, t);
                mat.color = currentColor;
                yield return null;
            }
            isCycling = false;
            goingForward = !goingForward;

        }
    }

}
