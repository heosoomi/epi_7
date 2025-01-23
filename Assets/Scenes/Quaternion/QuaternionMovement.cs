using Unity.Mathematics;
using UnityEngine;

public class QuaternionMovement : MonoBehaviour
{
    
    [SerializeField] Camera camMain;
    [SerializeField] float movespeed = 10f;
    

     float horz;
     float vert;

    void OnDrawGizmos()
    {
        // Vector3 forward = Vector3.forward *vert;
        // Vector3 right = Vector3.right *horz;
        // Vector3 direction = forward + right;

        // //Ray ? 광선
        // Gizmos.color = Color.green;
        // Gizmos.DrawRay(Vector3.zero,forward*5f);
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawRay(Vector3.zero,right*5f);
        // Gizmos.color = Color.red;
        // Gizmos.DrawRay(Vector3.zero,direction*5f);



        //카메라용 기즈모
        // camMain.transform.forward  카메라의 전방 벡터
        // camMain.transform.right    카메라의 오른쪽 벡터
        // camMain.transform.up       카메라의 업 벡터

        Gizmos.DrawRay(camMain.transform.position , camMain.transform.forward *10f); 

        
    }


    void Update()
    {

        //-1:Left, 0: Center, 1:Right
         horz = Input.GetAxis("Horizontal");
         vert = Input.GetAxis("Vertical");
        
        //회전 처리
         UpdateRotation();

         UpdatePoistion();
        

    }


    void UpdateRotation()
    {
        //Input.GetAxis() -> -1f ~ 1f 
         //Input.GetAxisRaw() -> -1, 0, 1
        
        //Quaternion rot = Quaternion.Euler(horz*100f,0f,0f);
        
        //Vector3 rightDir = Vector3.right * horz;
        //Vector3 forwardDir = Vector3.forward * vert;
        
        //Vector3 forward = new Vector3(camMain.transform.forward.x,0f,camMain.transform.forward.z) * vert;

        Vector3 forward = camMain.transform.forward * vert;
        forward.y = 0f;
        Vector3 right = camMain.transform.right * horz;
        right.y = 0f;


        //Vector3 forward = Vector3.forward * vert;
        //Vector3 right = Vector3.right * horz;
        Vector3 direction = forward + right;

        
        
        
        //forward.normalized -> -1~1까지 단위벡터 direction(방향)
        // if(forward.sqrMagnitude == 0)
        //     return;
        
        if(right.sqrMagnitude == 0)
            return;

        //Quaternion lookrot = Quaternion.LookRotation(forward); //필요없
        Quaternion lookrot = Quaternion.LookRotation(direction);
        transform.rotation = lookrot; 

        // float yAngle = transform.rotation.eulerAngles.y;

        // transform.rotation = Quaternion.Euler( 0f,yAngle ,0f );

    }

    void UpdatePoistion()
    {
        Vector3 moveDir = new Vector3(horz,0f,vert)* movespeed *Time.deltaTime;

        //이동 처리
         transform.position += moveDir;
    }

}
