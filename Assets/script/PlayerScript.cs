using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{


    private Actions actions;


    public FixedJoystick LeftJoystick;

    public FixedTouchField TouchField;

    private Rigidbody rb;
    protected float cameraAngley;
    protected float cameraAngleSpeed = 0.1f;
    protected float cameraPosY = 3f;
    protected float cameraPosSpeed = 0.02f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        actions = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = new Vector3(LeftJoystick.input.x, 0, LeftJoystick.input.y);

        var vel = Quaternion.AngleAxis(cameraAngley + 180, Vector3.up) * input * 5f;
        transform.rotation = Quaternion.AngleAxis(cameraAngley + Vector3.SignedAngle(input, input.normalized + Vector3.forward * 0.0001f, Vector3.up) + 180, Vector3.up);
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

        
        cameraAngley += TouchField.TouchDist.x * cameraAngleSpeed;
        cameraPosY = Mathf.Clamp(cameraPosY - TouchField.TouchDist.y * cameraPosSpeed, 0, 5f);



        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraAngley, Vector3.up) * new Vector3(0, cameraPosY, 3);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);




        if (LeftJoystick.Horizontal != 0f || LeftJoystick.Vertical != 0f)
        {
            //if i want to rotate player with joystick
            //transform.rotation = Quaternion.LookRotation(rb.velocity);

            actions.walkPlayer = true;
        }
        else
        {
            actions.walkPlayer = false;
        }

    }
}
