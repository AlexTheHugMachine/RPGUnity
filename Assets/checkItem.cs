using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkItem : MonoBehaviour
{
    //Actual item's ID
    private int itemID;

    //Character member
    public GameObject bodyPart;

    //Items list
    [SerializeField]
    public List<GameObject> itemList = new List<GameObject>();

    void Update()
    {
        if(transform.childCount > 0)
        {
            itemID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        else
        {
            itemID = 0;

            for(int i = 0; i < itemList.Count; i++)
            {
                itemList[i].SetActive(false);
            }
        }

        //If the game detects many items in the character's hand, we desactive them and leave the right one
        if(bodyPart.transform.childCount > 1)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                itemList[i].SetActive(false);
            }
        }

        //Basic Sword
        if(itemID == 1 && transform.childCount > 0)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(i == 0)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary sword
        if(itemID == 3 && transform.childCount > 0)
        {
            for(int i = 1; i < itemList.Count; i++)
            {
                if(i == 1)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Basic Axe
        if(itemID == 4 && transform.childCount > 0)
        {
            for(int i = 2; i < itemList.Count; i++)
            {
                if(i == 2)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary Axe
        if(itemID == 5 && transform.childCount > 0)
        {
            for(int i = 3; i < itemList.Count; i++)
            {
                if(i == 3)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Basic/Rare Bracers
        if(itemID == 9 && transform.childCount > 0)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(i == 0 || i == 1)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary Bracers
        if(itemID == 13 && transform.childCount > 0)
        {
            for(int i = 2; i < itemList.Count; i++)
            {
                if(i == 2 || i == 3)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary Helmet
        if(itemID == 2 && transform.childCount > 0)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(i == 0)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Basic Helmet
        if(itemID == 6 && transform.childCount > 0)
        {
            for(int i = 1; i < itemList.Count; i++)
            {
                if(i == 1)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Rare Helmet
        if(itemID == 7 && transform.childCount > 0)
        {
            for(int i = 2; i < itemList.Count; i++)
            {
                if(i == 2)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Epic Helmet
        if(itemID == 8 && transform.childCount > 0)
        {
            for(int i = 3; i < itemList.Count; i++)
            {
                if(i == 3)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary Breastplate
        if(itemID == 12 && transform.childCount > 0)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(i == 0)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Rare Shield
        if(itemID == 14 && transform.childCount > 0)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(i == 0)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary Shield
        if(itemID == 15 && transform.childCount > 0)
        {
            for(int i = 1; i < itemList.Count; i++)
            {
                if(i == 1)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Legendary Shoes
        if(itemID == 16 && transform.childCount > 0)
        {
            for(int i = 2; i < itemList.Count; i++)
            {
                if(i == 2 || i == 3)
                {
                    itemList[i].SetActive(true);
                }
            }
        }

        //Basic Shoes
        if(itemID == 17 && transform.childCount > 0)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(i == 0 || i == 1)
                {
                    itemList[i].SetActive(true);
                }
            }
        }
    }
}
