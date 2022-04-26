using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Animator animator;
    public Transform laser;
    private PlayerState state;
    public GameObject bullet;
    AudioSource audio;
    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && state.checkState(PlayerState.States.IDLING))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            animator.SetFloat("Velocity", 0);
            animator.SetTrigger("Shot");
            state.changeState(PlayerState.States.SHOOTING);
            RotateChar();
            Invoke(nameof(reload), 1);
            Invoke(nameof(createBullet), 0.3f);
        }
    }

    public void reload() {
        state.changeState(PlayerState.States.IDLING);
    }

    public void createBullet() {
        audio.Play();
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }

    public void RotateChar() {
        Vector3 forward = laser.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }
}
