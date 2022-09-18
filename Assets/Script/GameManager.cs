using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public
    public Canvas uiInventory;



    /*  Hide/Show the UI inventory
    *   @since version 0.1
    *   @version 1.0
    */
    public void switchUIInventory()
    {
        if (uiInventory.GetComponent<Canvas>().isActiveAndEnabled)
        {
            uiInventory.enabled = false;
        }
        else
        {
            uiInventory.enabled = true;
        }
    }
}
