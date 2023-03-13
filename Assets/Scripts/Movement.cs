using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainRocketThrustTune = 1000f;
    [SerializeField] float mainRocketRotationTune = 100f;
    [SerializeField] AudioClip thrusterSound;

    [SerializeField] ParticleSystem mainThrusterParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;


    Rigidbody rb;
    AudioSource thrustSound;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }

        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainRocketThrustTune);

        if (!thrustSound.isPlaying)
        {
            thrustSound.PlayOneShot(thrusterSound);
        }

        if (!mainThrusterParticle.isPlaying)
        {
            mainThrusterParticle.Play();
        }
    }

    void StopThrusting()
    {
        thrustSound.Stop();
        mainThrusterParticle.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotatingLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotatingRight();
        }

        else
        {
            StopRotating();
        }
    }

    void RotatingRight()
    {
        ApplyRotation(-mainRocketRotationTune);
        if (!rightThrusterParticle.isPlaying)
        {
            rightThrusterParticle.Play();
        }
    }

    void RotatingLeft()
    {
        ApplyRotation(mainRocketRotationTune);
        if (!leftThrusterParticle.isPlaying)
        {
            leftThrusterParticle.Play();
        }
    }

    void StopRotating()
    {
        leftThrusterParticle.Stop();
        rightThrusterParticle.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
