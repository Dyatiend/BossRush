using UnityEngine;

public class Attack : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;

    public GameObject hammer;
    private Collider hammerCollider;

    private SimpleAttack simpleAttack;
    private MegaPunch megaPunch;
    private SpellAttack spellAttack;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hammerCollider = hammer.GetComponent<Collider>();

        simpleAttack = GetComponent<SimpleAttack>();
        megaPunch = GetComponent<MegaPunch>();
        spellAttack = GetComponent<SpellAttack>();

    }


    void Update()
    {
        Vector3 forward = transform.forward;

        if (Input.GetMouseButtonDown(0))
        {
            simpleAttack.Attack();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            megaPunch.Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            spellAttack.Attack();
        }
    }

}
