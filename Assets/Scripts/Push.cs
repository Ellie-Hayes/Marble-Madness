using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        float force = 2000;
        if (collision.gameObject.tag == "Player")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            // This will push back the player
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }
    }
}
