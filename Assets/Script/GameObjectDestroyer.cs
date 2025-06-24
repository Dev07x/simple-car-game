using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
    }
}
