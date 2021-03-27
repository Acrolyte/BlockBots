using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
   // private float speed = 5f;
   public RectTransform reticle;
   private float wid = Screen.width;
   private float hei = Screen.height;

   private Vector2 startPos;
   private Vector2 direction;
   public bool directionChosen;
   
   private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x >= wid / 2)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        directionChosen = false;
                        break;
                    case TouchPhase.Moved:
                        direction = touch.position - startPos;
                        break;
                    case TouchPhase.Ended:
                        directionChosen = true;
                        break;
                }
            }

            //if (directionChosen)
            //{
                //Input.GetAxis("widx");
            //}
        }

       
        
    }
}
