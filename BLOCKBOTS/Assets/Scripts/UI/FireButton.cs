using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
  
    [HideInInspector] 
    public bool Pressed;
    
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = false;
    }
}
