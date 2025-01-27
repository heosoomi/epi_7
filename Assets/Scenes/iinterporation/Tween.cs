using UnityEngine;
using DG.Tweening;

public class Tween : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMoveX(1f,1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);

        //transform.DOScaleY(1.5f,1f).SetLoops(-1,LoopType.Yoyo);
        //위 아래 움직이면서 회전
        transform.DOLocalMoveY(1.5f,1f).SetLoops(-1,LoopType.Yoyo);
        transform.DOLocalRotate(new Vector3(0f,360f,0f0),1f ,RotateMode ,LoopType.Yoyo);
    }

    
}
