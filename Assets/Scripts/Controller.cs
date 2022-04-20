using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    enum PlayerState {
        IDLING,
        RUNNING,
        SHOOTING,
        THROWING,
        FAST_SHOOTING
    }

    AudioSource audio;

    private PlayerState state = PlayerState.IDLING;

    public Transform shotPoint;

    public Transform grenadePoint;
    public Transform laser;
    public float moveSpeed;
    public float rotationSpeed;
    public float walkAnimationSpeed;
    public Vector3 velocity;

    private Rigidbody rigidbody;
    private Animator animator;

    public GameObject camera;

    public Transform pointerTransform;

    public GameObject bullet;

    public GameObject grenadePrefab;

    public float cooldownThrowingGrenade = 10f;

    private float countdownThrowingGrenade = 0;

    private bool readyToThrowingGrenade = true;

    public float cooldownFastShooting = 5f;

    private float countdownFastShooting = 0;
    private bool readyToFastShooting = true;

    bool alreadyAttacked;    

    public float throwForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        ThrowGrenade();
        FastShoot();
        reduceCountdownFastShooting();
        reduceCountdownThrowingGrenade();
    }

    void reduceCountdownFastShooting() {
        countdownFastShooting -= Time.deltaTime;
        if(countdownFastShooting <= 0f && !readyToFastShooting) {
            readyToFastShooting = true;
        }
    }

    void reduceCountdownThrowingGrenade() {
        countdownThrowingGrenade -= Time.deltaTime;
        if(countdownThrowingGrenade <= 0f && !readyToThrowingGrenade) {
            readyToThrowingGrenade = true;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && state == PlayerState.IDLING)
        {
            animator.SetTrigger("Shot");
            state = PlayerState.SHOOTING;
            RotateChar();
            Invoke(nameof(reload), 1);
            Invoke(nameof(createBullet), 0.3f);
        }
    }

    void reload() {
        state = PlayerState.IDLING;
    }

    void createBullet() {
        audio.Play();
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }

    void RotateChar() {
        Vector3 forward = laser.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }

    void ThrowGrenade() {
        if(Input.GetKeyDown(KeyCode.Q) && state == PlayerState.IDLING && readyToThrowingGrenade) {
            state = PlayerState.THROWING;
            RotateChar();
            countdownThrowingGrenade = cooldownThrowingGrenade;
            readyToThrowingGrenade = false;
            animator.SetTrigger("Throw");
            Invoke(nameof(createGrenade), 0.3f);
        }
    }

    void createGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, grenadePoint.position, grenadePoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(grenadePoint.transform.forward * throwForce, ForceMode.VelocityChange);
        state = PlayerState.IDLING;
    }

    void FastShoot() {
        if(Input.GetKeyDown(KeyCode.E) && state == PlayerState.IDLING && readyToFastShooting) {
            state = PlayerState.FAST_SHOOTING;
            animator.SetTrigger("Fast");
            RotateChar();
            countdownFastShooting = cooldownFastShooting;
            readyToFastShooting = false;
            Invoke(nameof(createBullet), 0.3f);
            Invoke(nameof(createBullet), 0.7f);
            Invoke(nameof(createBullet), 1.1f);
            Invoke(nameof(reload), 1.2f);
        }
    }

    public void Move()
    {
        if((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && state == PlayerState.IDLING)
        {
            state = PlayerState.RUNNING;
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");

            Vector3 translation = Vector3.zero;

            translation = forward * camera.transform.forward;
            translation += right * camera.transform.right;
            translation.y = 0;

            if(translation.magnitude > 0.2f)
            {
                velocity = translation;
            }
            else
            {
                velocity = Vector3.zero;
            }

            rigidbody.velocity = new Vector3(velocity.normalized.x * moveSpeed, rigidbody.velocity.y, velocity.normalized.z * moveSpeed);
            Vector3 pos = transform.position;
            pos.y += 1;
            pointerTransform.position = pos;

            if (velocity.magnitude > 0.2f)
            {
      
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);

            }
            animator.SetFloat("Velocity", velocity.magnitude * walkAnimationSpeed);
            state = PlayerState.IDLING;
        }
    }
}
