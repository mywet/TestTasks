using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemname = default;
    public string GetItemName()
    {
        return itemname;
    }
}