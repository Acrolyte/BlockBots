using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonMovement : MonoBehaviour
{
    public static ThirdPersonMovement Instance { get; private set; }
    
    public CharacterController Controller;
   public Transform cam;
    //protected ThirdPersonUserControl Control;
    public FixedJoystick Joystick;
    public FloatingJoystick camstick;
    public JumpButton jumpbutton;
    public FireButton firebutton;
    
    public HealthBar healthBar;

    public int maxhealth = 100;
    public int currenthealth;
    
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpheight = 30f;

    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundMask;
    
    public float turnSmoothTime = 100f;
    private float turnsmoothvelocity;

    private Vector3 velocity;
    private bool isGrounded;
    protected bool jump;
    
    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;
    
    public bool giveDamage = false;
    private void Start()
    {
        jumpbutton = FindObjectOfType<JumpButton>();

        currenthealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (currenthealth <= 0)
        {
            PlayerManager.instance.KillPlayer();
        }
        
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

       
        float horizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        float xmove = camstick.Horizontal;
        float ymove = camstick.Vertical;
        Vector3 rot = new Vector3(xmove, 0f , ymove);
        
        float targetAngle = Mathf.Atan2(rot.x, rot.z) * Mathf.Rad2Deg +cam.eulerAngles.y;
        
        if (direction.z > 0.1f)
        {
            Vector3 north = Quaternion.Euler(0f, targetAngle, 0f) *Vector3.forward;
            Controller.Move(north.normalized * (speed * Time.deltaTime));
        }
        
        if (direction.z < -0.1f)
        {
            Vector3 south = Quaternion.Euler(0f, targetAngle, 0f) *Vector3.back;
            Controller.Move(south.normalized * (speed * Time.deltaTime));
        }
        
        if (direction.x > 0.1f)
        {
            Vector3 east = Quaternion.Euler(0f, targetAngle, 0f) *Vector3.right;
            Controller.Move(east.normalized * (speed * Time.deltaTime));
        }
        
        if (direction.x < -0.1f)
        {
            Vector3 west = Quaternion.Euler(0f, targetAngle, 0f) *Vector3.left;
            Controller.Move(west.normalized * (speed * Time.deltaTime));
        }
        
        
        if (rot.magnitude >= 0.1f)
        {
            float angle = Mathf.SmoothDamp(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnSmoothTime); 
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //Controller.Move(movedir.normalized * speed * Time.deltaTime);
        }

        
        if(jumpbutton.Pressed && !jump )
        {
            jump = true;
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        if (jump && !jumpbutton.Pressed )
        {
            jump = false;
        }
        
        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime); 
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthBar.SetHealth(currenthealth);
    }
}
