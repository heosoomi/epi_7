using System.Collections.Generic;
using System.Linq.Expressions;
using CustomInspector;
using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    //public int[] //배열 형태
    public List<int> datas = new List<int>();

    public List<string> dataStrs = new List<string>();
    public List<float> data = new List<float>();
    public List<GameObject> gameobj;
    public List<bool> databools;


  [Button("method3",true)] public int inputNum;
    void method3(int n)
    {
        //Debug.Log($"입력한 숫자{n}");

        //입력한 숫자를 리스트에 넣기

        datas.Add(n);
    }
    
    
    void AddData()
     {
    
    //     datas.Add()   //추가
    //     datas.Clear()   // 전체삭제
    //     datas.Remove()   //한개삭제
    //     datas.Find()    //특정 값을 찾음
    //     datas.Sort()    //정렬(오름차순, 내림차순)
    //     datas.Count     //총 개수
    //     datas.ForEach()  //배열 순회 출력
    }
    
    [Space(30),Button("ClearDatas",size = Size.small),HideField]public bool _b0;
    void ClearDatas()
    {
        datas.Clear();
    }

    
    [Space(30),Button("RemoveData",true,size = Size.small)]public int removeNum;

    void RemoveData(int n)
    {
        datas.Remove(n);
       // datas.RemoveAll() //조건에 부합하는 애만 전체 삭제
        //datas.RemoveAt()  //순번(index)에 해당하는 것만 삭제
    }

    [Space(30),Button("RemoveAtData",true, size = Size.small)]public int removeAtNum;

    void RemoveAtData(int i)
    {
        datas.RemoveAt(i); //순번(index)에 해당하는 것만 삭제

        //a에 해당하는 데이터가 있는지? 
        //참: 지워라, 거짓: 패스

        //datas.Contains(값)
        if (datas.Exists(a => a == i) == false)
        {
            return;
        }
        //datas.Find()

        //try catch
        
    }
    [Space(30),Button("SortData", size = Size.small),HideField]public bool _b1;
    void SortData()
    {
        //기본 정렬해보기
        datas.Sort();
        
    }

    [Space(30),Button("ShowAllFor", size = Size.small),HideField]public bool _b2;
    void ShowAllFor()
    {
        // 리스트의 모든 데이터를 출력해보기
        // 반복문 -> for, while, foreach
        //datas.count는 리스트 안의 총 데이터 갯수
        for(int i = 0; i<datas.Count;i++)
        {
            Debug.Log($"{i} : {datas[i]}");
        }


    }
    [Space(30),Button("ShowAllWhile", size = Size.small),HideField]public bool _b3;
    void ShowAllWhile()
    {
        int i = 0; 
        while(i<datas.Count)
        {
            Debug.Log($"{i} : {datas[i]}");
            i++;
        }


    }
    
    [Space(30),Button("ShowAllForeach", size = Size.small),HideField]public bool _b4;
    void ShowAllForeach()
    {
        //리스트의 모든 값을 출력 : foreach문
        //foreach의 존재 이유? 리스트를 위해 만들어짐
        //in 뒤에 리스트를 넣으면 알아서 1바퀴 값을 전달해줌
        //따라서 증감표현 필요없
        //초기값 설정 필요없
       foreach (var v in datas)
        {
            Debug.Log(v);  
        }

        datas.ForEach(v => Debug.Log(v));
    }

}

