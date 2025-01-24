
using Deform;
using UnityEngine;

public class QuaternionMovement : MonoBehaviour
{
    [SerializeField] SquashAndStretchDeformer deform;
    [SerializeField] Camera camMain;
    [SerializeField] float movespeed = 10f;    // 이동속도
    [SerializeField] float JumpPower = 5f;     // 점프능력
    [SerializeField] float JumpDuration = 1f;  // 지속시간 
    

     float horz;
     float vert;
     public bool isJumping;

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

        //Gizmos.DrawRay(camMain.transform.position , camMain.transform.forward *10f); 

        
    }


    void Update()
    {

        //-1:Left, 0: Center, 1:Right
         horz = Input.GetAxis("Horizontal");
         vert = Input.GetAxis("Vertical");
         //Jump = Input.GetButton("Jump");
         //Jump = Input.GetButtonDown("Jump");
        
        //회전 처리
         UpdateRotation();
        //이동 처리
         UpdatePoistion();

         UpdateJump();

        //camMain.transform.forward // 카메라의 전방 벡터
        //camMain.transform.right // 카메라의 오른쪽 벡터
        //camMain.transform.up    // 카메라의 업 벡터
        

    }


    void UpdateRotation()
    {
        //Input.GetAxis() -> -1f ~ 1f 
         //Input.GetAxisRaw() -> -1, 0, 1
        
        //Quaternion rot = Quaternion.Euler(horz*100f,0f,0f);
        
        //Vector3 rightDir = Vector3.right * horz;
        //Vector3 forwardDir = Vector3.forward * vert;
        
        //Vector3 forward = new Vector3(camMain.transform.forward.x,0f,camMain.transform.forward.z) * vert;

         Vector3 forward;
        if (camMain.transform.eulerAngles.x != 90)
        {
            forward = camMain.transform.forward * vert;
            forward.y=0f;
        }
        else 
        {
            forward= camMain.transform.up * vert;
        }

        
        
        // Vector3 forward = camMain.transform.forward * vert;
        // forward.y = 0f;
        Vector3 right = camMain.transform.right * horz;
        right.y = 0f;
        Vector3 direction = forward + right;


        //Vector3 forward = Vector3.forward * vert;
        //Vector3 right = Vector3.right * horz;
        //Vector3 direction = forward + right;

        
        
        
        //forward.normalized -> -1~1까지 단위벡터 direction(방향)
        // if(forward.sqrMagnitude == 0)
        //     return;
        
        if(direction.sqrMagnitude == 0)
            return;

        //Quaternion lookrot = Quaternion.LookRotation(forward); //필요없
        Quaternion lookrot = Quaternion.LookRotation(direction);
        transform.rotation = lookrot; 

        // float yAngle = transform.rotation.eulerAngles.y;

        // transform.rotation = Quaternion.Euler( 0f,yAngle ,0f );

    }

  

    void UpdatePoistion()

    {

        Vector3 forward;
        if (camMain.transform.eulerAngles.x != 90)
        {
            forward = camMain.transform.forward * vert;
            forward.y=0f;
        }
        else 
        {
            forward= camMain.transform.up * vert;
        }

        // Vector3 forward = camMain.transform.forward * vert;
        // forward.y = 0f;
        Vector3 right = camMain.transform.right * horz;
        right.y = 0f;
        Vector3 direction = (forward + right).normalized;


        Vector3 moveDir = direction * movespeed * Time.deltaTime;
        
        //이동 처리
         transform.position += moveDir;

        //  Debug.DrawRay(transform.position, moveDir*100f ,Color.blue);

        
    }

    
    // public Vector3 jumpStartPosition;
    public float jumpstartTime;

    float jumpChargedTime;

    float jumpforceCharged;
    void UpdateJump()
    {
        

        if(  Input.GetButtonDown("Jump"))
        {
            jumpChargedTime = Time.time;
            
            deform.Factor = -0.15f;
        }

        if(Input.GetButtonUp("Jump") && isJumping == false)
        {
            jumpstartTime = Time.time;
            jumpforceCharged = jumpstartTime - jumpChargedTime;

            jumpforceCharged = Mathf.Clamp(jumpforceCharged,1f,5f);

            deform.Factor = 0.06f;
            isJumping = true;
        }
        

        

        // if( Jump )
        // {
        //     jumpstartTime = Time.time;
        //     jumpStartPosition = transform.position;
        // }

        //포물선 방정식
        //공식1 : y =  (x - x * x)
        //공식2 : y = x * (1-x)

        //y는 점프 높이, x는 시간 변화량 (percent)
        
        //시간 변화 ?  
        //DeltaTime = Time.deltaTime; //1f 동안 걸린 시간
        //NowTime = Time.time; // 현재 시간

        // (현재시간 -과거 기준 시간) / 측정할 시간


        if(isJumping == true)
        {

        float percent = (Time.time - jumpstartTime) / JumpDuration; //퍼센트 구하기

        //(percent<1) : 포물선 안에서 작동중( 0 ~ 1 )
        if(percent < 1)
        {
            float jumpheight =  (percent - percent * percent) * (JumpPower * jumpforceCharged) ; //점프 높이 (포물선 방정식)
            transform.position = new Vector3(transform.position.x,jumpheight,transform.position.z); //

        }

        else
        {
            isJumping = false;
            deform.Factor = 0f;
        }

        }
        




         

    }











}   


