using System.Collections.Generic;
using CustomInspector;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;


public class Array1 : MonoBehaviour
{
    //[Range(0,10)]public int []num;
    //[Range(0.0f,2.0f)]public List<int> numList;

    //public GameObject objprefabs;


    public int [] numArray;
    //public int [] numArray1 ={1,3,5,7};

    public string [] nameArray;
    public string nameFind;

    [Space(30),Button("ArrayGetValue",size = Size.small),HideField]public bool _b0;

    void ArrayGetValue()
    {
        //Debug.Log($"{numArray.Length}");

        //Debug.Log($"{numArray.GetValue(0)}");  

        //Debug.Log($"{numArray.GetValue(0)}");
       // Debug.Log($"{numArray[2]}");
    }


    [Space(30),Button("ArrayLoop",size = Size.small),HideField]public bool _b1;
    void ArrayLoop()
    {
        for(int a=0; a < numArray.Length; a++)
        {
            Debug.Log($"{numArray[a]}");
        }
    }

    [Space(30),Button("ArrayLoop2",size = Size.small),HideField]public bool _b2;
    void ArrayLoop2()
    {
        int index = 0;
        foreach(int a in numArray)
        {
            Debug.Log($"index {index} : {a}");
            index++;
        }
    }


 [Space(30),Button("ArrayFind",size = Size.small),HideField]public bool _b3;
    void ArrayFind()
    {
        // if(nameFind == nameArray)
        // {
        //    foreach(string a in nameArray)
        //    {
        //      Debug.Log($"{nameFind}")
        //    } 
        // }


        for(int i=0; i<nameArray.Length; i++)
        {
            Debug.Log($"{i}");
            return;

            if("cherry" == nameArray[i])
            {
                Debug.Log($"corret!   index{i}");
                break;
            }
           
              
        }
      
      Debug.Log($"못찾음");
    }


     
}
