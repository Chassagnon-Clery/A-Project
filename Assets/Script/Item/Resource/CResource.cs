using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResource : CItem
{
    //Public
    public int resourceAmount;
    protected CPlayer Player;



    /*  Start is called before the first frame update
    *   @version 1.0
    */
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<CPlayer>();
    }



    /*  Interaction with a resource
    *   @since version 0.1
    *   @version 1.1
    */
    public void interact(int resourceCollect)
    {
        int maxStack = Player.canStackToInventory(this, resourceCollect);

        if (maxStack > 0)
        {
            if (maxStack < resourceCollect)
            {
                resourceCollect = maxStack;
            }

            resourceAmount -= resourceCollect;

            if (resourceAmount > 0)
            {
                itemAmount = resourceCollect;
                Player.addItemToInventory(this);
            }
            else
            {
                itemAmount = resourceAmount + resourceCollect;
                Player.addItemToInventory(this);
                destroyResource();
            }
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }



    /*  Destroy the resource when empty
    *   @since version 0.1
    *   @version 1.0
    */
    public void destroyResource()
    {
        Destroy(this.gameObject);
    }
}
