using System.Collections;
using UnityEngine;

public class TraficManager : MonoBehaviour
{
    [SerializeField] Transform[] lanes;
    [SerializeField] GameObject[] trafficVehicles; 
    [SerializeField] CarCantroller carCantroller;
    [SerializeField] float minSpwantime = 30f;
    [SerializeField] float maxSpwantime = 60f;

    private float dynamincSpwanTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine( TrafficSpawner());


    }

    // Update is called once per frame
    IEnumerator TrafficSpawner()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (carCantroller.CarSpeed() > 20f)
            {
                dynamincSpwanTime = Random.Range(minSpwantime, maxSpwantime) / carCantroller.CarSpeed();

                SpwanTrafficVehical();
            }
            yield return new WaitForSeconds(dynamincSpwanTime);
        }

    }
    void SpwanTrafficVehical()
    {
        int randomLane = Random.Range(0, lanes.Length);
        int randomTrafficVehicleIndex = Random.Range(0, trafficVehicles.Length);

        Instantiate(trafficVehicles[randomTrafficVehicleIndex], lanes[randomLane].position, Quaternion.identity);

    }
}
