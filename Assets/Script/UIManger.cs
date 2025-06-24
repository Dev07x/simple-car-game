using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] CarCantroller carCantroller;
    [SerializeField] Transform carTransform;
    [SerializeField] TextMeshProUGUI scoreText;
    private float speed = 0f;
    private float distance = 0f;
    private float score = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        DistanceUI();
        SpeedUI();
        ScoreUI();

    }
    void DistanceUI()
    {
        distance =carTransform.position.z/1000;
        distanceText.text = distance.ToString("0.00" + "km");
    }
    void SpeedUI()
    {
        speed = carCantroller.CarSpeed();
        speedText.text = speed.ToString("0" + "km/h");
    }
    void ScoreUI()
    {
        score = carTransform.position.z *6;
        scoreText.text= score.ToString("0");
    }
}
