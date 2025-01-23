using CustomInspector;
using UnityEngine;

public class Vector3Rotate : MonoBehaviour
{
    public float Pitch;  //X축 회전 : Pitch, Vertical (w key ,s key)

    public float Yaw;    //y축 회전 : Yaw, Horizental (A key ,D key )

    public float Roll;   //z축 회전 : Roll

    public float rotateSpeed = 20f;

    void Update()
    {
        Yaw = Input.GetAxis("Horizental")* rotateSpeed * Time.deltaTime;
        Pitch = Input.GetAxis("Vertical")* rotateSpeed * Time.deltaTime;
        
        transform.Rotate(new Vector3(Pitch,Yaw,Roll)* Time.deltaTime);

        //if(transform.Rotate(new Vector3(Pitch,Yaw,Roll)))

    }


   [Button("GimbalrockRotate",label="짐발락"),HideField] public bool _b0;

   void GimbalrockRotate()
   {

   }
}
