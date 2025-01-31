
using System.Collections.Generic;
using DG.Tweening;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Tween2Sequence : MonoBehaviour
{
   public List<Vector3> targetPos;
   


    void Start()
    {
        //SequenceMove();
        SequenceMoveLoop();
    }



    void SequenceMove()
    {
        //Append : 시퀀스 뒤에 첨가 ,DOTween 함수를 바로 사용
        //AppendInterval : 시퀀스 뒤에 첨가 ,지정한 시간을 지연시킴
        //AppendCallback : 시퀀스 뒤에 첨가 ,일반적인 함수를 람다형식으로 사용
        Sequence seq = DOTween.Sequence();
         
       
        seq.AppendInterval(1f);
        seq.Append(transform.DOMove(targetPos[0],1f));
        //rotate
        seq.Append(transform.DOLocalRotate(Vector3.up * 90f, 0.25f/*시간*/));
        //movement
        seq.Append(transform.DOMove(targetPos[1],1f));

        seq.Append(transform.DOLocalRotate(Vector3.up * 180f, 0.25f/*시간*/));
        seq.Append(transform.DOMove(targetPos[2],1f));


        seq.Append(transform.DOLocalRotate(Vector3.up * 270f, 0.25f/*시간*/));
        seq.Append(transform.DOMove(targetPos[3],1f));
        seq.Append(transform.DOLocalRotate(Vector3.up * 360f, 0.25f/*시간*/));

        seq.SetLoops(-1);
        //seq.AppendCallback( ()=> Debug.Log("시퀀스 종료"));

        

    } 
    
    void SequenceMoveLoop()
    {
        Sequence seq = DOTween.Sequence();
        
        int r = 1;
        
        foreach(Vector3 v in targetPos)
        {

            seq.Append(transform.DOMove(v,1f));
            seq.Append(transform.DOLocalRotate(Vector3.up * 90f*r, 0.25f/*시간*/));
            r++;
        }
        
        




        
        // for(int a = 1; a < 5; a++)
        // {
        //     seq.Append(transform.DOMove(targetPos[a],1f));
        // }


    }
        Vector3 rndpos = Vector3.zero;
    void SequenceMovewander()
    {
        Sequence seq = DOTween.Sequence();
        


        seq.AppendCallback(()=>
        {
            transform.LookAt(rndpos);
            
            Quaternion.LookRotation(rndpos-transform.position);
        });
        
        //seq.AppendCallback( ()=> rndpos = Random.insideUnitSphere * 10f);
        seq.AppendInterval(0.25f);
       // seq.AppendCallback(transform.DOMove(rndpos,1f));
        seq.SetLoops(-1);
    }
    void Sequence1()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        seq.AppendCallback(() => Debug.Log("1초")); 
        seq.AppendInterval(1f);
        seq.AppendCallback(() => Debug.Log("2초"));
        seq.AppendInterval(1f);
        seq.AppendCallback(() => Debug.Log("3초"));
    
    }
    
}
