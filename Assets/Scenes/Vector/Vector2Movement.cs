using UnityEngine;
using CustomInspector;


public class Vector2Movement : MonoBehaviour
{

    //input
    //Legacy (오래된 버전의 입력장치)
    //키보드, 마우스, 모바일(터치) 입력을 처리

    //[SerializeField, ReadOnly] Vector2 movement;
    [SerializeField]float movespeed = 1f; 
    [SerializeField]float rotateSpeed = 1f; 

    void Update()
    {
        //버튼을 누르면 참 -> 실행 , 안누르면 거짓 -> 패스
        //켓버튼 누른 상태인가? 뗀 상태인가?

        // if (Input.GetButton("Fire1"))
        // {
        //     Debug.Log($"눌렀음");
        // }

        // if(Input.GetButtonDown("Jump"))
        // {
        //     Debug.Log($"jump down");
        // }

        // if(Input.GetButtonUp("Jump"))
        // {
        //     Debug.Log($"jump up");
        // }

        float horz = Input.GetAxis("Horizontal");
        Debug.Log($"horz = {horz}");

        //movement에 horz, vert 값 적용해보기
        
        float vert = Input.GetAxis("Vertical");
        Debug.Log($"vert = {vert}");



        //마우스로 회전 -> 키보드로 이동
        //키보드로 회전,이동한다

        //horz로 회전만 vert 이동
        //horz a왼쪽 회전, d 오른쪽
        //vert w키 앞, s키 뒤로

        //이동 방향에 따라 회전을 따라간다

        //Time.deltaTime ? 결과 값을 어느 사양에서도 동일하게 만들어준다.

        transform.Rotate(0f,horz * rotateSpeed * Time.deltaTime,0f);

        //movement = new Vector2(horz,vert);
        transform.Translate(/*horz Time.deltaTime*movespeed*/0f,0f,vert * Time.deltaTime*movespeed);



    }
}
