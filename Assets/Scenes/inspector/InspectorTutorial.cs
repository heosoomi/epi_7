using UnityEngine;
using CustomInspector;

public class InspectorTutorial : MonoBehaviour
{
    [Title("인스펙터꾸미기",fontSize =20, alignment = TextAlignment.Center)]
   

   [HorizontalLine("세부속성",color: FixedColor.IceWhite),HideField] public bool _l0;
  
   public int testNum1;
   [Range(0,5)]public int testNum2;
   [Range(0.0f,1.0f)] public float testNum3;
   
   [RichText(true)]
   public string testString;
   [Multiline(lines:4)]
   public string testString2;

   [TextArea(minLines:2,maxLines:10)]
   public string testString3;

   
    [HorizontalLine(0.5f,FixedColor.IceWhite),HideField] public bool _l1;
    
    [Preview(Size.big)]public Sprite sprite;

    [Space(30),Button("method1",size = Size.small),HideField]public bool _b0;
    [Space(1.5f), Button("method2",size = Size.small),HideField]public bool _b2;

    [Space(30),ReadOnly(DisableStyle.OnlyText)]public string TextReadOnly = "readOnlyTest";
    [Space(50),HideField] public bool _b1;

   void method1()
   {
        Debug.Log("method test");
   }

   void method2()
   {
        Debug.Log("method test2");
   }
    [Button("method3",true)] public int inputNum;
    void method3(int n)
    {
        Debug.Log($"입력한 숫자{n}");
    }

}
