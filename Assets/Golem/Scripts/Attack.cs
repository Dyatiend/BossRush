using UnityEngine;

public class Attack : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;

    public GameObject hammer;
    private Collider hammerCollider;

    //----- Виды атак ----------
    private SimpleAttack simpleAttack;
    private MegaPunch megaPunch;
    private SpellAttack spellAttack;

    //------КД -----------------
    public float AttackCoolDown;
    public float AbilityCoolDown;
    public float UltimateCoolDown;

    private float AttackCoolDown2;
    private float AbilityCoolDown2;
    private float UltimateCoolDown2;

    private bool canAttack;
    private bool canAbility;
    private bool canUltimate;

    public Transform laser;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hammerCollider = hammer.GetComponent<Collider>();

        simpleAttack = GetComponent<SimpleAttack>();
        megaPunch = GetComponent<MegaPunch>();
        spellAttack = GetComponent<SpellAttack>();

        canAbility = true;
        canUltimate = true;
        canAttack = true;

        AbilityCoolDown2 = AbilityCoolDown;
        UltimateCoolDown2 = UltimateCoolDown;
        AttackCoolDown2 = AttackCoolDown;

    }


    void Update()
    {
        Vector3 forward = transform.forward;

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            RotateChar();
            canAttack = false;
            simpleAttack.Attack();
        }
        if (Input.GetKeyDown(KeyCode.Q) && canUltimate)
        {
            RotateChar();
            canUltimate = false;
            megaPunch.Attack();          
        }
        if (Input.GetKeyDown(KeyCode.E) && canAbility)
        {
            RotateChar();
            canAbility = false;
            spellAttack.Attack();        
        }

        countCooldown();
    }

    public void RotateChar()
    {
        Vector3 forward = laser.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }

    private void countCooldown()
    {
        if (!canAbility)
        {
            AbilityCoolDown2 -= Time.deltaTime;
            if (AbilityCoolDown2 < 0)
            {
                canAbility = true;
                AbilityCoolDown2 = AbilityCoolDown;
            }
        }

        if (!canUltimate)
        {
            UltimateCoolDown2 -= Time.deltaTime;
            if (UltimateCoolDown2 < 0)
            {
                canUltimate = true;
                UltimateCoolDown2 = UltimateCoolDown;
            }
        }

        if (!canAttack)
        {
            AttackCoolDown2 -= Time.deltaTime;
            if (AttackCoolDown2 < 0)
            {
                canAttack = true;
                AttackCoolDown2 = AttackCoolDown;
            }
        }

    }

}
