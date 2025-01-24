using NUnit.Framework;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform target;
    
    public Vector3 offset;

    public float movespeed = 1f;
    public bool isLerp;

    
    void Update()
    {

        if(isLerp)
        {
            moveLerp();        
        }
        else
        {
            MoveToward();
        }

    }
    
    //Lerp: A에서 B로 간다 (등가속 운동)
    void moveLerp()
    {
        Vector3.Lerp(transform.position, target.position + offset,movespeed * Time.deltaTime);
    }
    
          
    //MoveToward : target 위치로 간다 (등속 운동르로 )


   void MoveToward()
   {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, movespeed * Time.deltaTime) ;
   }
}
