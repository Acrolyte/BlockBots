using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerController : MonoBehaviour
{

public float player_move_speed=14.7f;
public float player_rotate_speed=7.5f;


    // Update is called once per frame
    void Update()
    {
        //Move Front/Back
        if (MobileJoystickUI.Instance.moveDirection.y != 0)
        {
            transform.Translate(transform.forward * Time.deltaTime * player_move_speed * MobileJoystickUI.Instance.moveDirection.y, Space.World);
        }

        //Rotate Left/Right
        if (MobileJoystickUI.Instance.moveDirection.x != 0)
        {
            transform.Rotate(new Vector3(0, 14, 0) * Time.deltaTime * player_rotate_speed * MobileJoystickUI.Instance.moveDirection.x, Space.Self);
        }
    }
}
