
using UnityEngine;
using UnityEngine.Events;

public class Pickable : MonoBehaviour
{
    Vector3 _temp;
   
    void OnTriggerEnter(Collider col)
    {
        
        Debug.Log($"TriggerEnter {col.name}");
            
            if(col.tag != "Item")
                return;
            
            //Destroy(col.gameObject);

            //Debug.Log($"{col.transform.localScale*3}");
            _temp = col.transform.localScale;
            col.transform.localScale = _temp * 3f;
        
    }
//충돌체가 탈출 했을 때
    void OnTriggerEixt(Collider col)
    {
        if(col.tag != "Item")
                return;
            
             _temp = col.transform.localScale;
             col.transform.localScale = _temp / 3f;
    }
    
    //충돌체가 머무르고 있을 때
    void OnTriggerStay(Collider col)
    {

    }
    
    
    // void OncollisionEnter()
    // {
    //     Debug.Log("코인 +1");
        
    //     Destroy(gameObject);
    // }

    

}

