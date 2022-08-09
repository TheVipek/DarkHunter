using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform position1, position2;
    public float Speed;
    public Transform startingPos;

    Vector3 nextPosition;

    

    private void Start()
    {
        nextPosition = startingPos.position;
    }

    private void Update()
    {
        if (transform.position == position1.position)
        {
            nextPosition = position2.position;


        }

        if (transform.position == position2.position)
        {
            nextPosition = position1.position;
        }


        
         transform.position = Vector3.MoveTowards(transform.position, nextPosition, Speed * Time.deltaTime);
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }



    
}
