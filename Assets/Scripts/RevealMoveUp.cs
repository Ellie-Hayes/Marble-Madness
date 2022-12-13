using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealMoveUp : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 moveToPos;
    public Vector3 slay;
    public float speed = 50f;
    public float waitDivider;
    public int waitMinus; 
    public bool canMove = false;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        moveToPos = transform.position;
        startPos = moveToPos;
        startPos.y -= 10;

        slay = new Vector3(startPos.x - 1000, startPos.y, startPos.z);
        transform.position = slay;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveToPos, step);

            if (Vector3.Distance(transform.position, moveToPos) < 0.01)
            {
                canMove = false; 
            }
        }
        else if(!done)
        {
            StartCoroutine("wait");
        }

    }

    IEnumerator wait()
    {
        done = true;
        Transform playerPad = transform.parent;
        float distance = Vector3.Distance(playerPad.transform.position, startPos);
        float waitTime = (distance / waitDivider) - waitMinus;
        
        yield return new WaitForSeconds(waitTime);
        transform.position = startPos;
        canMove = true;
        
        
    }
}
