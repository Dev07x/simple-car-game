using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform carTransform;
    public Transform cameraPointtransform;

    public Vector3 velocity =Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(carTransform);
        transform.position = Vector3.SmoothDamp(transform.position, cameraPointtransform.position, ref velocity, 5f*Time.deltaTime);
    }
}
