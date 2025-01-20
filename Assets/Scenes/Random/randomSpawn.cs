
using System.Collections.Generic;
using System.Data;
using CustomInspector;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
        //에디터에서 기즈모를 그릴수 있는 공간(예약함수)
     void OnDrawGizmos()
     {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position, radius * 2f );

        //Gizmos.DrawWireCube(transform.position, Vector3.one *radius);
     }
    //프리팹 -> 인스턴스화 (instantiate) -> 리스트에 여러 프리팹 -> 랜덤 스폰

    [SerializeField] Transform propRoot; //프랍들을 모아놓을 그룹 root

    [SerializeField] GameObject prefab;
    [SerializeField] float radius;
    [SerializeField] float yoffset;
    [SerializeField,AsRange(0.75f,1.3f)] Vector2 scaleRange; 


    [Button("Spawn"),HideField] public bool _b0;
    public void Spawn()
    {
        
        
        //Instantiate(prefab,new Vector3(0,0,0),Quaternion.identity);
        GameObject clone = Instantiate(prefab);
        Vector3 rndpos = Random.insideUnitSphere * radius *0.5f + transform.position;
        
        //Vector3(x,y,z)
        //Vector2(x,y)
        //float(x)
        //Vector4(x,y,z,w)
        //Color(r,g,b,a)

        float x = Random.Range(scaleRange.x,scaleRange.y);
        
        
        
        //clone.transform.position = new Vector3(x,0.5f,z);

        clone.transform.position = new Vector3(rndpos.x,0.5f + yoffset,rndpos.z);
        clone.transform.SetParent(propRoot);

        //크기를 랜덤하게 조절한다
        clone.transform.localScale = new Vector3(x,x,x);
        
        //Random.value

        //        
        //변수 Range만큼 증폭하여 위치 이동
    }

        
    [Button("Despawn"),HideField] public bool _b1;
    public void Despawn()
    {
        //Destroy 플레이 모드에서 삭제할때
        //DestroyImmediate 에디터 모드에서 삭제할때

        //propRoot.childCount //자식 수를 가져온다

        //propRoot.transform //리스트 자료구조 형

        foreach( Transform t in propRoot)  //리스트에 뭐가 있든 한번씩 값을 가져온다
        {
            //Debug.Log($"{v}");
            
        DestroyImmediate(t.gameObject);
            
        }

    }




}


