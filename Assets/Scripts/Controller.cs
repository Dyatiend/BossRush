using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform shotPoint;
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

    bool alreadyAttacked;    

    public float throwForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
        {
            Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }

        Shoot();
        ThrowGrenade();
        FastShoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !alreadyAttacked)
        {
            animator.SetTrigger("Shot");
            alreadyAttacked = true;
            RotateChar();
            Invoke(nameof(reload), 1);
            Invoke(nameof(createBullet), 0.3f);
        }
    }

    void reload() {
        alreadyAttacked = false;
    }

    void createBullet() {
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
        if(Input.GetKeyDown(KeyCode.Q)) {
            RotateChar();
            GameObject grenade = Instantiate(grenadePrefab, shotPoint.position, shotPoint.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(shotPoint.transform.forward * throwForce, ForceMode.VelocityChange);
        }
    }

    void FastShoot() {
        if(Input.GetKeyDown(KeyCode.E)) {
            animator.SetTrigger("Fast");
            RotateChar();
            Invoke(nameof(createBullet), 0.3f);
            Invoke(nameof(createBullet), 0.7f);
            Invoke(nameof(createBullet), 1.1f);
        }
    }

    void kostyl() {
        animator.SetBool("FastShoting", false);
    }

    public void Move(float forward, float right)
    {
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
    }
}
