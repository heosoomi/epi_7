
using UnityEngine;



public class regidbodyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float gravity = 3f;
    [SerializeField] float moveSpeed;
     [SerializeField] float JumpForce;

    private float horz,vert;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        InputKeyboard();
        Rotate();
    }

    void InputKeyboard()
    {
        horz=Input.GetAxisRaw("Horizental");
        vert=Input.GetAxisRaw("Vertical");
        jump.GetButtonDown


        Vector3 forward = cameraTransform.forward*vert;
        forward.y = 0f;
        Vector3 right = cameraTransform.right*horz;
        right.y = 0f;
         
        Vector3 direction = (forward + right).normalized;
        Vector3 movement = new Vector3(horz,0f,vert);

    }
    void  Movement()
    {
        //rb.linearVelocity = new Vector3(horz,0f,vert) * moveSpeed*Time.deltaTime;
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity,movement*moveSpeed,Time.deltaTime*10f);

    }
    void Rotate()
    {
        if(movement == Vector3.zero)
            return;
        
        Quaternion targetrotation = Quaternion.LookRotation(movement);

        rb.rotation = Quaternion.Slerp(rb.rotation,targetrotation, Time.deltaTime);
    }
    void CustumGravity()
    {
        rb.useGravity = false;

        rb.AddForce(Physics.gravity*2f,ForceMode.Acceleration);
    }
    void Jump()
    {
        if(jump)
            rb.AddExplosionForce
    }
}

