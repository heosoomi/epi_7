using System.Collections.Generic;
using CustomInspector;

using UnityEngine;

public class randomSpawn : MonoBehaviour
{
        //에디터에서 기즈모를 그릴수 있는 공간(예약함수)
     void OnDrawGizmos()
     {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position, radius );

        //Gizmos.DrawWireCube(transform.position, Vector3.one *radius);
     }
    //프리팹 -> 인스턴스화 (instantiate) -> 리스트에 여러 프리팹 -> 랜덤 스폰

[Title("prop spawner",fontSize =20, alignment = TextAlignment.Center)]
   
    [SerializeField] Transform propRoot; //프랍들을 모아놓을 그룹 root

    [SerializeField,Preview(Size.medium)] List<GameObject> prefabs;
    

    [SerializeField] LayerMask layerMask;
[HorizontalLine(0.5f,FixedColor.IceWhite),HideField] public bool _l1;

    [SerializeField,Range(0,150)] float radius;
    [SerializeField,Range(0,1000)]int maxNumByClick;

    [SerializeField] float yoffset;


    [SerializeField,AsRange(0.75f,1.3f)] Vector2 scaleRange; 
    [SerializeField, AsRange(-90f,90f)] Vector2 rotateX;
    [SerializeField,AsRange(-90f,90f)] Vector2 rotateY;
    [SerializeField,AsRange(-90f,90f)] Vector2 rotateZ;



[HorizontalLine(0.5f,FixedColor.IceWhite),HideField] public bool _l2;

    [Button("Spawn"),HideField] public bool _b0;
    public void Spawn()
    {
        
        Vector3 hitpoint;

        //거짓 : 빈 공간 -> 함수 탈출
        if (checkHeight(out hitpoint))
            return;

        

        //변수 Range만큼 증폭하여 위치 이동
        //GameObject clone = null;
        
        //Instantiate(prefab,new Vector3(0,0,0),Quaternion.identity);
        
        //prefab; // Game object
        //prefabs; //List<>

        //리스트 안의 데이터 수 :prefabs.Count;
        //prefabs[0] :리스트의 첫번째 값
        //prefabs[prefabs.Count-1] : 리스트의 마지막 값 
        
        int rndcnt = Random.Range(0,prefabs.Count);
        GameObject clone = Instantiate(prefabs[rndcnt]);
       
       // Vector3 rndpos = Random.insideUnitSphere * radius  + transform.position;
        Vector3 rndpos = Random.insideUnitSphere * radius  + transform.position;
        //Vector3(x,y,z)
        //Vector2(x,y)
        //float(x)
        //Vector4(x,y,z,w)
        //Color(r,g,b,a)

        float x = Random.Range(scaleRange.x,scaleRange.y);
        
        
        
        //clone.transform.position = new Vector3(x,0.5f,z);

        clone.transform.position = new Vector3(rndpos.x,hitpoint.y,rndpos.z);
        clone.transform.SetParent(propRoot);

        //크기를 랜덤하게 조절한다
        clone.transform.localScale = new Vector3(x,x,x);
        
        //clone.transform.rotation = quaternion을 배운 뒤
         //rotateX 최소값
         //rotateY 최대값
         
        float rndrotX = Random.Range(rotateX.x,rotateZ.y);
        float rndrotY = Random.Range(rotateY.x,rotateY.y);
        float rndrotZ = Random.Range(rotateZ.x,rotateZ.y);


        clone.transform.Rotate(new Vector3(rndrotX,rndrotZ,rndrotY));
        
    }
    [Button("SpawnLoop"),HideField] public bool _b3;
    void SpawnLoop()
    {
        //int rnd=(int)Random.Range(maxNumByClick , maxNumByClick);
        for(int i=0; i< maxNumByClick; i++)
        {
            
            Spawn();
        }
    }


    [Button("Despawn"),HideField] public bool _b1;
    public void Despawn()
    {
        //Destroy 플레이 모드에서 삭제할때
        //DestroyImmediate 에디터 모드에서 삭제할때

        //propRoot.childCount //자식 수를 가져온다

        //propRoot.transform //리스트 자료구조 형

// //foreach는 값 전달, 인덱스 알아서
//         foreach( Transform t in propRoot)  //리스트에 뭐가 있든 한번씩 값을 가져온다
//         {
//             //Debug.Log($"{v}");
//             //t = 나무, transform = 기즈모
//             if (CheckInside(t.position,transform.position))
//                 DestroyImmediate(t.gameObject);
            
//         }

//for는 인덱스, 값은 알아서 구해라
        for(int i =propRoot.childCount - 1; i >= 0; i-- )
        {
            Transform t = propRoot.GetChild(i);
            if (CheckInside(t.position,transform.position))
                DestroyImmediate(t.gameObject);
        }
    }

//원 안에 들어왔는지 확인하는 함수
    bool CheckInside(Vector3 A, Vector3 B)
    {

        //두 점 사이의 거리를 구하기
        float dist = Vector3.Distance(A,B);
        return dist <= radius; 

        // //충돌 안했음
        // if (dist > radius)
        // {
        //     return false;
        // }
        // //충돌 했음
        // else
        // {
        //     return true;
        // }
    
    }
    //생성할 오브젝트와 지형이 만나는 지점
    bool checkHeight( out Vector3 hitpoint)
    {
      
      //기준점 Gizmo -> spawner 의 위치를 기준으로 일정 높이 위에서 Ray를Cast한다
            RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 30f, -Vector3.up, out hit, 1000.0f,layerMask))
            {
                //참 : 충돌했다 -> 충돌한 위치가 어디냐? -> 그 위치에 나무를 심는다
                //충돌지점
                hitpoint = hit.point;
                return true;
            }

            //거짓 : 충돌 안한다 -> 패스
                 hitpoint=Vector3.zero;
                return false;

    }

    


}


