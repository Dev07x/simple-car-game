using UnityEngine;

public class LaneMovment : MonoBehaviour
{
    [SerializeField] Transform playerCarTransform;
    [SerializeField] float offset = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerCarTransform.position.z + offset;
        transform.position = cameraPos;

    }
}
