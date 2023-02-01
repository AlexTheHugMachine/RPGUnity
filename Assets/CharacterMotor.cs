using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMotor : MonoBehaviour
{
    //Character's animations
    Animation animations;

    //Move speed
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    //Attack
    public float attackCooldown;
    private bool isAttacking;
    private float currentCooldown;
    public float attackRange;
    public GameObject rayHit;

    //Inputs
    public string inputFoward;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;
    PlayerInventory playerInv;

    //Character dead or no
    public bool IsDead = false;

    //Spells
    public GameObject lightningSpellGO;
    public float lightningSpellCost;
    public float lightningSpellSpeed;
    public int lightningSpellID;
    public Sprite lightningSpellImage;

    public GameObject HealSpellGO;
    public float HealSpellCost;
    public float HealSpellAmount;
    public int HealSpellID;
    public Sprite HealSpellImage;

    private GameObject raySpell;
    private GameObject SpellHolderIMG;
    public int currentSpell = 1;
    public int totalSpell;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        playerInv = gameObject.GetComponent<PlayerInventory>();
        rayHit = GameObject.Find("RayHit");
        raySpell = GameObject.Find("RaySpell");
        SpellHolderIMG = GameObject.Find("SpellHolderIMG");
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y -0.1f, playerCollider.bounds.center.z), 0.08f);
    }

    void Update()
    {
        if(!IsDead)
        {
            //To go foward
            if(Input.GetKey(inputFoward) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, walkSpeed * Time.deltaTime);

                if(!isAttacking)
                {
                    animations.Play("walk");
                }

                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }

                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    AttackSpell();
                }
            }

            //To go foward and sprint
            if(Input.GetKey(inputFoward) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
                animations.Play("run");
            }

            //To go back
            if(Input.GetKey(inputBack))
            {
                transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
                if(!isAttacking)
                {
                    animations.Play("walk");
                }
                
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }

                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    AttackSpell();
                }
            }

            //Left Rotation
            if(Input.GetKey(inputLeft))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }

            //Right Rotation
            if(Input.GetKey(inputRight))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }

            //Stand animation
            if(!Input.GetKey(inputFoward) && !Input.GetKey(inputBack))
            {
                if(!isAttacking)
                {
                    animations.Play("idle");
                }
                
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }

                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    AttackSpell();
                }
            }

            //Jump animation
            if(Input.GetKeyDown(KeyCode.O) && IsGrounded()) //Space doesn't work in the editor
            {
                //Jump preparation
               Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                v.y = jumpSpeed.y;

                //Jump
                gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
            }
        }

        if(isAttacking)
        {
            currentCooldown -= Time.deltaTime;
        }

        if(currentCooldown <= 0)
        {
            currentCooldown = attackCooldown;
            isAttacking = false;
        }

        //Spell switch
        //back
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentSpell <= totalSpell && currentSpell != 1)
            {
                currentSpell -= 1;
            }
        }

        //forward
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentSpell >= 0 && currentSpell != totalSpell)
            {
                currentSpell += 1;
            }
        }

        //Spell picture switch
        if(currentSpell == lightningSpellID)
        {
            SpellHolderIMG.GetComponent<Image>().sprite = lightningSpellImage;
        }

        if(currentSpell == HealSpellID)
        {
            SpellHolderIMG.GetComponent<Image>().sprite = HealSpellImage;
        }
    }

    public void Attack()
    {
        if(!isAttacking)
        {
            animations.Play("attack");
            RaycastHit hit;

            if(Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
            {
                Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);

                if(hit.transform.tag == "test")
                {
                    print(hit.transform.name + " detected");
                }
            }

            isAttacking = true;
        }
    }

    public void AttackSpell()
    {
        if(currentSpell == lightningSpellID && !isAttacking && playerInv.currentMana >= lightningSpellCost)
        {
            animations.Play("attack");
            GameObject theSpell = Instantiate(lightningSpellGO, raySpell.transform.position, transform.rotation);
            theSpell.GetComponent<Rigidbody>().AddForce(transform.forward * lightningSpellSpeed);
            playerInv.currentMana -= lightningSpellCost;
            isAttacking = true;
        }

        if(currentSpell == HealSpellID && !isAttacking && playerInv.currentMana >= HealSpellCost && playerInv.currentHealth < playerInv.maxHealth)
        {
            animations.Play("attack");
            Instantiate(HealSpellGO, raySpell.transform.position, transform.rotation);
            playerInv.currentMana -= HealSpellCost;
            playerInv.currentHealth += HealSpellAmount;
            isAttacking = true;
        }
    }
}
