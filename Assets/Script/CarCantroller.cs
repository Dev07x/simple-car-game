using UnityEngine;

public class CarCantroller : MonoBehaviour
{
    public WheelCollider FrontLeftWheelColider;
    public WheelCollider FrontRightWheelColider;
    public WheelCollider backLeftWheelColider;
    public WheelCollider backRightWheelColider;

    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;
    public Transform frontLeftWheelTransform;

    public Transform carCenterOfMassTransform;
    public Rigidbody rigidbody;

    public float brakeForce = 1000f;
    public float motorForce = 100f;
    public float maxSteerAngle = 30f;
    float verticalInput;
    float horizontalInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody.centerOfMass = carCenterOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MotorForce();
        UpdateWheels();
        GetInput();
        Steering();
        ApplyBreaks();
        PowerSteering();

    }
    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void ApplyBreaks()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FrontLeftWheelColider.brakeTorque = brakeForce;
            FrontRightWheelColider.brakeTorque = brakeForce;
            backLeftWheelColider.brakeTorque = brakeForce;
            backRightWheelColider.brakeTorque = brakeForce;
            rigidbody.linearDamping = 1f;
        }
        else
        {
            FrontLeftWheelColider.brakeTorque = 0;
            FrontRightWheelColider.brakeTorque = 0;
            backLeftWheelColider.brakeTorque = 0;
            backRightWheelColider.brakeTorque = 0;
            rigidbody.linearDamping = 0f;
        }
    }
        void MotorForce()
    {
        FrontLeftWheelColider.motorTorque=motorForce* verticalInput;
        FrontRightWheelColider.motorTorque=motorForce* verticalInput;

    }
    void Steering()
    {
        FrontLeftWheelColider.steerAngle = maxSteerAngle * horizontalInput;
        FrontRightWheelColider.steerAngle = maxSteerAngle * horizontalInput;
    }
    void PowerSteering()
    {
        if( horizontalInput == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0f, 0f, 0f),Time.deltaTime);
        }
    }
        void UpdateWheels()
    {
        RotateWheel(FrontRightWheelColider, frontRightWheelTransform);

        RotateWheel(FrontLeftWheelColider, frontLeftWheelTransform);
        RotateWheel(backLeftWheelColider, backLeftWheelTransform);
        RotateWheel(backRightWheelColider, backRightWheelTransform);


    }
    void RotateWheel(WheelCollider WheelCollider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        transform.SetPositionAndRotation(pos, rot);
    }
    public float CarSpeed()
    {
        float speed = rigidbody.linearVelocity.magnitude * 2.23693629f;
        return speed;
    }
}
