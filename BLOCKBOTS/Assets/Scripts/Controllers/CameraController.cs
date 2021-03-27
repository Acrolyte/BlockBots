using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool LockCursor = false;
    public Transform Target;
    public bool smoothfollow = false;
    public float FollowSpeed = 10f;
    public Vector3 PositionOffset;
    private Vector3 smoothPosition;
    public float x { get; private set; }
    public float y { get; private set; }
    public float Sensitivity = 3f;
    public float YMin = -89, YMax =89;
    public float Yoffset;

    private void Awake()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        smoothPosition = transform.position;
    }

    void LateUpdate()
    {
        Cursor.lockState = LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = LockCursor ? false : true;
        x += Input.GetAxis("Mouse X") * Sensitivity;
        y = ClampYAngle(y - Input.GetAxis("Mouse Y") * Sensitivity, YMin + Yoffset, YMax - Yoffset);
        Quaternion rotation = Quaternion.AngleAxis(x, Vector3.up) * Quaternion.AngleAxis(y, Vector3.right);
        if (smoothfollow)
            smoothPosition = Target.position;
        else
        {
            smoothPosition = Vector3.Lerp(smoothPosition, Target.position, Time.deltaTime * FollowSpeed );
        }

        Vector3 t = smoothPosition + rotation * PositionOffset;
        Vector3 f = rotation * -Vector3.forward;
        transform.position = t + f;
        transform.rotation = rotation * Quaternion.Euler(Vector3.right * Yoffset);
    }

    private float ClampYAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
