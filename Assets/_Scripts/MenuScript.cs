using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Text TextArea;
    public string txt;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("MOUSE OEVERRRRRERER");
        txt = txt.Replace("\\n","\n");
        TextArea.text = txt;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("MOUSE OEVERRRRRERER");
        TextArea.text = "";
    }
    
}
