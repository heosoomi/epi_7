

using CustomInspector;
using Unity.Mathematics;
using UnityEngine;


    // Euler Angle (오일러 앵글)
    // 디그리(Degree) :일반적인 각도 표현 // 라디안(radian) : 수학, 물리 각도표현 단위
    // 0 도 ~ 360 도 , Pie(π) = 180 도 , 2 π = 360 도

    // 1radian = 57.30도  2radian = 114.6 도  3radian = 171.9도  3.14 radian = 180도
    // 6 radian = 360 도

    // 이동 관련 -> Vector
    // 회전 관련 -> Quaternion
    // 크기 관련 -> vector3

    // Quaternion 구성 -> Vector4 형채
public class Quaternion1 : MonoBehaviour
{

    //Quaternion 용 속성
    
   
    public float Pitch;  //X축 회전 : Pitch, Vertical (w key ,s key)

    public float Yaw;    //y축 회전 : Yaw, Horizental (A key ,D key )

    public float Roll;   //z축 회전 : Roll

    public float rotateSpeed = 20f;

 

    public GameObject targetobj;


        void Update()
    {
        // Yaw = Input.GetAxis("Horizental")* rotateSpeed * Time.deltaTime;
        // Pitch = Input.GetAxis("Vertical")* rotateSpeed * Time.deltaTime;

        // Quaternion rotation = Quaternion.Euler(Pitch,Yaw,Roll);

        // transform.rotation = rotation;


        LookRotationSmooth();
    }


     [Button("QuaternionElement",label="쿼터니언 기본 속성"),HideField] public bool _b1;

    void QuaternionElement()
    {
        Debug.Log( $"{Quaternion.identity}");
    }


    [Button("LookRotate"),HideField] public bool _b2;
    void LookRotate()
    {
        // vector 뺄셈 : 방향
        // Vector A - B : B가 A를 바라보는 방향 (값 : Vector 3 )
        // B - A : A가 B를 바라보는 방향
        
        // forward : z+ 전방
        // up y+ :
        // right x+
        
        Vector3 lookdirection = targetobj.transform.position-transform.position;
        
        transform.rotation = Quaternion.LookRotation(lookdirection);

        //Quaternion.LookRotation(lookdirection,transform.right);

        // 

    }

    void LookRotationSmooth()
    {

        //타켁 위치 - 내 위치 -> 내가 타겟을 바라보는 방향 vector
         Vector3 lookdirection = targetobj.transform.position - transform.position;
        
        // 내 캐릭터가 타겟을 바라보도록 Quaternion를 연산한다
         Quaternion lookrot = Quaternion.LookRotation(lookdirection);
            

        // RotateTowards : 부드럽게 바라보도록 Quaternion을 연산해준다
        // RotateTowards(기준 회전 quaternion, 목표 회전 quaternion, 단위 회전 속도* time.delta~)
        transform.rotation = Quaternion.RotateTowards(transform.rotation,lookrot,rotateSpeed*Time.deltaTime) ;

        // transform 내 자신의 트랜스폼
        // transform.rotation 회전정보 (타입: Quaternion)
        // transform.rotation.eulerAngles 회전정보 -> 오일러 앵글로 변환한 값
        // (Quaternion -> Vector3)
        float yAngle = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler( 0f,yAngle ,0f );
         
    }

}
