using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSkills : MonoBehaviour
{
    public GameObject UIpannel;
    public Text pointsText;

    public int availablePoints;
    public string openKey;

    private bool isOpen;
    private PlayerInventory playerinv;

    void Start()
    {
        playerinv = gameObject.GetComponent<PlayerInventory>();
    }


    void Update()
    {
        if(Input.GetKeyDown(openKey))
        {
            isOpen = !isOpen;
        }

        if(isOpen)
        {
            pointsText.text = "Available points : " + availablePoints;
            UIpannel.SetActive(true);
        }
        else
        {
            UIpannel.SetActive(false);
        }
    }

    public void addHealthMax(float amountHP)
    {
        if(availablePoints >= 1)
        {
            playerinv.maxHealth += amountHP;
            playerinv.currentHealth += amountHP;
            availablePoints -= 1;
        }
    }

    public void addManaMax(float amountMana)
    {
        if(availablePoints >= 1)
        {
            playerinv.maxMana += amountMana;
            playerinv.currentMana += amountMana;
            availablePoints -= 1;
        }
    }

    public void LifeMax()
    {
        if(availablePoints >= 1)
        {
            playerinv.currentHealth = playerinv.maxHealth;
            availablePoints -= 1;
        }
    }

    public void ManaMax()
    {
        if(availablePoints >= 1)
        {
            playerinv.currentMana = playerinv.maxMana;
            availablePoints -= 1;
        }
    }
}
