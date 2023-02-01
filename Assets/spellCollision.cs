using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellCollision : MonoBehaviour
{
    public float spellDamage;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<ennemyAI>().ApplyDammage(spellDamage);
        }

        if(col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
