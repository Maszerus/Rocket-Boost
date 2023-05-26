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
        if (period <= Mathf.Epsilon) {return;}      //Mathf.Epsilon - smallest possible number in float grater that 0, better than comparing to zero!!!
        float cycle = Time.time / period;           //constantly growing over tome

        const float tau = Mathf.PI * 2;             //constant value of 6,283
        float rawSinWave = Mathf.Sin(cycle * tau);  //going from -1 to 1 - check sin in wiki or something if not remember

        movementVector = (rawSinWave + 1f) / 2f;    //recalculating to go from 0 to 1 so its cleaner

        Vector3 offset = movementVector * moveToPosition;
        transform.position = startingPosition + offset;
    }
}
