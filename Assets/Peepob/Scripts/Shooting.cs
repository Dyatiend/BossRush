using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Animator animator;
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
        
    }

    public void Shoot()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Shot");
        state.changeState(PlayerState.States.SHOOTING);
        Invoke(nameof(reload), 1.15f);
        Invoke(nameof(createBullet), 0.3f);
    }

    public void reload() {
        state.changeState(PlayerState.States.IDLING);
    }

    public void createBullet() {
        audio.Play();
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }
}
