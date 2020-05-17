using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnThirdPersonController : MonoBehaviour {


    public FixedJoystick LeftJoystick;

    public FixedTouchField TouchField;
    public float JumpForce = 5f;
    protected Actions Actions;
    protected Rigidbody Rigidbody;

    protected float CameraAngleY;
    protected float CameraAngleSpeed = 0.1f;
    protected float CameraPosY = 3f;
    protected float CameraPosSpeed = 0.02f;
    

    

    // Use this for initialization
    void Start ()
    {
        Actions = GetComponent<Actions>();
        Rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    

    private void Walk()
    {
        //Control.m_Jump = Button.Pressed;
        //Control.Hinput = LeftJoystick.inputVector.x;
        //Control.Vinput = LeftJoystick.inputVector.y;
        var input = new Vector3(LeftJoystick.input.x, 0, LeftJoystick.input.y);

        var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up) * input * 5f;
        transform.rotation = Quaternion.AngleAxis(CameraAngleY + Vector3.SignedAngle(Vector3.forward, input.normalized + Vector3.forward * 0.0001f, Vector3.up) + 180, Vector3.up);
        Rigidbody.velocity = new Vector3(vel.x, Rigidbody.velocity.y, vel.z);

        CameraAngleY += TouchField.TouchDist.x * CameraAngleSpeed;
        CameraPosY = Mathf.Clamp(CameraPosY - TouchField.TouchDist.y * CameraPosSpeed, 0, 5f);

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleY, Vector3.up) * new Vector3(0, CameraPosY, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

    }
    
    
}