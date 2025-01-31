using UnityEngine;
using DG.Tweening;
using System.Linq.Expressions;
using CustomInspector;

public class Tween : MonoBehaviour
{

    public float duration; 
    public Ease ease = Ease.Unset;

    [Space]
    public MeshRenderer meshrender;
    public Color meshcolor;

    [Space]
    public RotateMode rotatemode;


    private Vector3 initPos;
    private Color initColor;


    //게임 오브젝트가 시작될때 한번 호출 , 용도 : 초기값 설정해준다
    void Start()
    {
        MoveY();

        initPos =transform.position;
        initColor = meshrender.material.color;
        
        // transform.DOLocalMoveX(1f,1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);

        // //transform.DOScaleY(1.5f,1f).SetLoops(-1,LoopType.Yoyo);
        // //위 아래 움직이면서 회전
        // transform.DOLocalMoveY(1.5f,1f).SetLoops(-1,LoopType.Yoyo);
        // transform.DOLocalRotate(new Vector3(0f,360f,0f),1f ,RotateMode.LocalAxisAdd)
        //                         .SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
    
    
    
    
    }
    // OnDestroy : 게임 오브젝트가 끝날 때 (삭제 될 때 ) 한번 호출, 용도 : 사용한 리소스들 청소(삭제)
    void OnDestroy()
    {
        DOTween.KillAll();
    }

[Button("MoveY"),HideField]public bool _b0;
    void MoveY()
    {
        KillMoveY();
        
        transform.position = initPos;
        transform.DOLocalMove(new Vector3(-6.8f,2f,-11f),duration)
                    .SetLoops(1,LoopType.Yoyo)
                    .SetEase(ease)
                    .OnComplete(()=> ChangeColor());

        //transform.DOLocalMoveY(2f,duration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
               
        //       () =>
        //fuction(){ }
    }
    [Button("KillMoveY"),HideField]public bool _b1;

    void KillMoveY()
    {
       //DOTween.Kill : 현재 동작중인 TWEEN의 Thread를 지운다 ( 삭제 )
       DOTween.Kill(transform);
    }

    void ChangeColor()
    {
        DOTween.Kill(meshrender.material);
        meshrender.material.color = initColor;
        meshrender.material.DOColor(meshcolor, duration).SetLoops(1,LoopType.Yoyo);

        //meshrender.material.DOFade(0f,duration).SetLoops(-1,LoopType.Yoyo);
    }

    void Move()
    {
        DOTween.Kill(transform);
        DOTween.Kill(meshcolor);

        //위아래 움직임 반복
         transform.position = initPos;
        transform.DOLocalMoveY(3f,duration).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        //한방향 회전 계속
        transform.DOLocalRotate(Vector3.up*360f,duration,rotatemode)
                                .SetLoops(-1,LoopType.Incremental)
                                .SetEase(ease);
        //스케일 조절
        transform.DOScale(1.5f, duration).SetLoops(-1,LoopType.Yoyo);

        meshrender.material.color = initColor;
        meshrender.material.DOColor(meshcolor,duration).SetLoops(-1,LoopType.Yoyo);
    }
}
