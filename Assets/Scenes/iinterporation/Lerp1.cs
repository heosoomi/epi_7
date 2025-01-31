using UnityEngine;


//lerp : Linear Interpolation(선형 보간)
//보간 ? 두 지점 사이의 값

//Slerp: 
public class Lerp1 : MonoBehaviour
{
    
    public Transform A;
    public Transform B;

    public bool isLerp;
    [Range(0f,1f)]public float t;


    void Update()
    {
        
        MoveSlerp();
        movelerp();
    }

    void MoveSlerp()
    {
        transform.position = Vector3.Slerp(A.position,B.position,t);

        
    }


    void movelerp()
    {

        t = Mathf.PingPong(Time.time,1f);
        transform.position = Vector3.Lerp(A.position,B.position,t);
    }
}
