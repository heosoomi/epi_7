using CustomInspector;
using Unity.Burst;
using UnityEngine;

public class Vector1 : MonoBehaviour
{
    //힘, 방향

    public float force = 10f; // Scalar 힘
    //Vector3 forcedirection = new Vector3 (10f,0f,0f); // 벡터 = 힘+방향

    public Vector3 Va ;
    public Vector3 Vb; 
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AaddB; 
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AminusB; 

    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AmultiForce; 
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AmultiForceNomalize; 


    public float magnitude;


    void OnDrawGizmos()
    {

        //DrawVectorElement();
        DrawVectorOperation();

    }
    
    void DrawVector1()
    {
        
        //from은 원점 to는 힘과 방향이 적용된 벡터
        //Gizmos.DrawLine(from, to);
        //벡터의 강도(힘)
        //magnitude = to.magnitude;

    }
    [Button("VectorElement",label = "벡터 기본 속성"),HideField]public bool _b0;

    void VectorElement()
    {
        Debug.Log($"벡터 제로 = {Vector3.zero}");
        Debug.Log($"벡터 원 = {Vector3.one}");


        //유니티 좌표계 : 왼손 좌표계
        //검지 = Forward Vector = Z+
        //  엄지  = up Vector = Y+
        //  중지   = right Vector = x+


        Debug.Log($"벡터 업 = {Vector3.up}");             //0,1,0
        Debug.Log($"벡터 다운 ={Vector3.down}");          //0,-1,0
        Debug.Log($"벡터 포워드 ={Vector3.forward}");     //0,0,1
        Debug.Log($"벡터 백 ={Vector3.back}");            //0.0.-1
        Debug.Log($"벡터 라이트 ={Vector3.right}");        //1,0,0
        Debug.Log($"벡터 레프트 ={Vector3.left}");         //-1,0,0
        

    }
    void DrawVectorElement()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Vector3.zero,Vector3.up);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Vector3.zero,Vector3.forward);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero,Vector3.right);
    }

    void DrawVectorOperation()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Vector3.zero,Va);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero,Vb);

        //벡터간 덧셈가능
        AaddB = Va + Vb;
        Gizmos.color = new Color(1f,0f,0f);
        Gizmos.DrawRay(Vector3.zero,AaddB);
        
        //벡터간 뺄셈 가능 
        // 둘 사이의 기준벡터 거리(방향)
        AminusB = Va - Vb;
        Gizmos.color = new Color(1f,0f,1f);
        Gizmos.DrawRay(Vector3.zero,AaddB);
        
        //벡터간 곱셈 불가능
        //AmultiB = Va * Vb

        //벡터와 float 곱셈 : 가능
        AmultiForce = Va * force;

        //벡터의 정규화(nomalize) :-1~1사이 값으로
        AmultiForceNomalize = AmultiForce.normalized;
        
        Gizmos.color = new Color(0f,0f,0f);
        Gizmos.DrawRay(Vector3.zero, AmultiForceNomalize);
    
    
    }

}
