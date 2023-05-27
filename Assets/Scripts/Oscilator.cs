using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 moveToPosition;

    float movementVector;
    [SerializeField] float period = 2f;


    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    void Update()
    {
        ObstacleMovement();
    }

    void ObstacleMovement()
    {
        if (period <= Mathf.Epsilon) {return;} 
        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2; 
        float rawSinWave = Mathf.Sin(cycle * tau); 

        movementVector = (rawSinWave + 1f) / 2f; 

        Vector3 offset = movementVector * moveToPosition;
        transform.position = startingPosition + offset;
    }
}
