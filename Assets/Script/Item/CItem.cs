using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem : MonoBehaviour
{
    public enum type
    {
        resource,
    }

    public type itemType;
    public string itemName;
    public string itemDescription;
    public bool itemIsStackable;
    public int itemMaxByStack;
    public int itemAmount;
}
