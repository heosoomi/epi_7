using System.Collections.Generic;
using CustomInspector;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Title("프랍 생성기", fontSize = 15, alignment = TextAlignment.Center), HideField] public bool _t0;


    [Space(10), HorizontalLine("프리팹"), HideField] public bool _l0;

    // 프랍들을 모아놓을 그룹 Root (부모)
    [SerializeField] Transform propRoot;


    // 프리펩 (Prefab) -> 인스턴스화 (Instantiate) -> 리스트에 여러 프리펩 -> 랜덤 스폰 
    [SerializeField, Preview(Size.medium)] List<GameObject> prefabs;



    [Space(10), HorizontalLine("배치 속성",color:FixedColor.PressedBlue), HideField] public bool _l1;

    [SerializeField] LayerMask layerMask;
    [SerializeField, Range(1f,200f)] float radius;  //반지름

    //int : -21억 ~ 21억 , uint : 0 ~ 42억
    [SerializeField, AsRange(1,1000)] Vector2 maxNumByRange;
    //[SerializeField] float yOffset; // y 높이조절


    [Space(10), HorizontalLine("회전 속성",color:FixedColor.PressedBlue), HideField] public bool _l2;

    [SerializeField, AsRange(-90f, 90f)] Vector2 rotateXaxis;   // x축 회전 범위
    [SerializeField, AsRange(-180f, 180f)] Vector2 rotateYaxis;   // x축 회전 범위
    [SerializeField, AsRange(-90f, 90f)] Vector2 rotateZaxis;   // z축 회전 범위


    [Space(10), HorizontalLine("크기 속성",color:FixedColor.PressedBlue), HideField] public bool _l3;
    [SerializeField, AsRange(0.5f, 2f)] Vector2 scaleRange; // 크기 범위 설정



    // 에디터에서 기즈모를 그릴수 있는 공간 (예약함수)
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position , radius);
    }



    [Space(10), HorizontalLine("버튼"), HideField] public bool _l4;

    [Button("Spawn"), HideField] public bool _b1;
    public void Spawn()
    {


        Vector3 rndpos = Random.insideUnitSphere * radius + transform.position;

        // CheckHeight 를 활용해서
        // 스폰 가능한지 ? 아닌지 ? 판단하고 생성
        Vector3 hitpoint;

        // 거짓 : 빈 공간 -> 함수 탈출
        if ( CheckHeight(rndpos, out hitpoint) == false )
            return;

        // 참 : 기존 계획대로 함수 실행



        //prefab; // GameObject
        //prefabs; // List<GameObject>


        // 리스트 안의 데이터 수 : prefabs.Count;
        // 리스트 의 인덱스 를 통한 값 가져오기
        
        // prefabs[0] : 리스트의 첫번째 값
        // prefabs[prefabs.Count-1] : 리스트의 마지막 값

        int rndcnt = Random.Range(0, prefabs.Count);
        //Instantiate 생성
        GameObject clone = Instantiate(prefabs[rndcnt]);


                
        //Vector3 rndscl = Random.insideUnitSphere; // -1 ~ 1
        //float rndscl = Random.value;
        float rndscl = Random.Range(scaleRange.x, scaleRange.y);

        //float   (x)
        //Vector2 (x,y)
        //Vector3 (x,y,z)
        //Vector4 (x,y,z,w)        
        //Color   (r,g,b,a)


        // Transform : 변형
        // 1. 위치(position) , 회전(rotation) , 크기(scale)
        // 2. 계층구조(Hierarchy), 부모-자식 (Parent-Child)

        // GameObject > Tranform
        // 1. 생성 ( Instantiate )
        // 2. 삭제 ( Destroy(플레이모드) , DestroyImmediate(에디터모드) )


        // 크기를 랜덤하게 조절한다
        clone.transform.localScale = new Vector3(rndscl, rndscl, rndscl);



        // 위치를 랜덤하게 조절한다.
        // = new Vector3(x,y,z)  활용해서 평면에 위치하게 한다        
        //clone.transform.position = new Vector3(hitpoint.x, hitpoint.y, hitpoint.z);
        clone.transform.position = hitpoint;

        //clone.transform.rotation =  "Quaternion 을 배운후에 다룬다"
        // 최소값
        // 최대값
        float rndrotX = Random.Range(rotateXaxis.x, rotateXaxis.y);
        float rndrotY = Random.Range(rotateYaxis.x, rotateYaxis.y);
        float rndrotZ = Random.Range(rotateZaxis.x, rotateZaxis.y);
        clone.transform.Rotate(new Vector3(rndrotX, rndrotY, rndrotZ));

        clone.transform.SetParent(propRoot);

        // (0.0f ~ 1.0f) => x10  (0f ~ 10f)
        //Random.value 
        // 3개 (-1f~1f, -1~1f, -1~1f)
        //Random.insideUnitSphere * 10f;
    }


    [Button("SpawnLoop"), HideField] public bool _b2;
    void SpawnLoop()
    {
        int rnd = (int)Random.Range(maxNumByRange.x, maxNumByRange.y);
        for (int i = 0; i < rnd; i++)
        {
            Spawn();
        }
    }


    [Button("Despawn"), HideField] public bool _b3;
    void Despawn()
    {
        //Destroy 플레이모드에서 삭제할때
        //DestroyImmediate 에디터모드 삭제할때
        
        //propRoot.childCount   // 자식 수 를 가져온다
        //propRoot              // 리스트 자료구조 형
        //DestroyImmediate()    // 에디터에서 지우는 함수
        // 변수(Variables)
        
        // foreach문 값 전달, 인덱스는 알아서 구해라
        // foreach(Transform t in propRoot)  // 리스트에 뭐가있든 한번씩 값을 가져오는것
        // {
        //     // t 는 나무 , transform 은 기즈모
        //     if (CheckInside(t.position, transform.position))
        //         DestroyImmediate(t.gameObject);

        //     //Debug.Log($"{v}");
        // }     

        //for , while , foreach
        // for문 인덱스 전달, 값은 알아서 구해라
        for ( int i = propRoot.childCount-1; i >= 0; i-- )
        {
            Transform child = propRoot.GetChild(i);
            if (CheckInside(child.position, transform.position))
                DestroyImmediate(child.gameObject);
        }

    }  


    [Space(30), HideField] public bool _s1;

    
    // 원 안에 들어왔는지 검사하는 함수 => 충돌 했다 , 안했다
    bool CheckInside(Vector3 A, Vector3 B)
    {
        // 두 점 사이의 거리 구하기
        float dist = Vector3.Distance(A,B);

        return dist <= radius;

        // 충돌 했음
        // if (dist <= radius)
        // {
        //     return true;
        // }
        // // 충돌 안했음
        // else
        // {
        //     return false;
        // }

    }

    

    // 생성할 오브젝트와 지형이 만나는 지점을 찾는다
    bool CheckHeight(Vector3 clonepoint, out Vector3 hitpoint)
    {
        // 기준점 : Gizmo -> Spawner 의 위치를 기준으로 일정 높이 위에서 Ray 를 Cast 한다.
        RaycastHit hit;

        if (Physics.Raycast(clonepoint + Vector3.up * 30f, -Vector3.up, out hit, 1000.0f, layerMask))
        {
            //참 ? 충돌했다 => 충돌한 위치가 어디냐 ? => 그 위치에 나무를 심는다  
            
            // 충돌지점
            hitpoint = hit.point;
            return true;
        }            
        //거짓 ? 충돌 안했다 => 패스

        hitpoint = Vector3.zero;
        return false;
    }

    
}
