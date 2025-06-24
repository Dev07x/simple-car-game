using UnityEngine;

public class endlessCity : MonoBehaviour
{
    [SerializeField] Transform playerCarTransform;
    [SerializeField] Transform otherCityTransform;
    [SerializeField] float halfLength =0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerCarTransform.position.z > transform.position.z + halfLength)
        {
            transform.position = new Vector3(0,0, otherCityTransform.position.z + halfLength*2);
        }
        
    }
}
