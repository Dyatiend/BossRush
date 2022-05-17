using UnityEngine;

public class Chidori : MonoBehaviour
{
    public int Speed;
    public int TimeDestroy;
    Vector3 beginPos;

    private AudioSource projectileSound;
    private bool canMove;

    void Start()
    {
        beginPos = transform.position;
        canMove = false;

        projectileSound = GetComponent<AudioSource>();
        projectileSound.Play();
        Invoke(nameof(allowMove), 1f);

    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        /*RaycastHit hit;

        if (Physics.Linecast(beginPos, transform.position, out hit))
        {
            print(hit.transform.name);

            Destroy(gameObject);
        }

        Destroy(gameObject, TimeDestroy);*/
    }


    private void allowMove()
    {
        canMove = true;
    }
}
