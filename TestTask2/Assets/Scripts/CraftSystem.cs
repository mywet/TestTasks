using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject woodtableprefab;

    [SerializeField]
    private GameObject stoneaxeprefab;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CraftWoodTable();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CraftStoneAxe();
        }
    }
    private void CraftWoodTable(int woodforcraft = 4)
    {
        var wood = GetWood();
        if (wood.Count >= woodforcraft)
        {
            for (int i = 0; i < woodforcraft; i++)
            {
                Destroy(wood[i].gameObject);
            }
            Instantiate(woodtableprefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Not Enough Materials");
        }
    }
    private void CraftStoneAxe(int woodforcraft = 3, int stoneforcraft = 2)
    {
        var wood = GetWood();
        var stone = GetStone();
        if (wood.Count >= woodforcraft && stone.Count >= stoneforcraft)
        {
            for (int i = 0; i < woodforcraft; i++)
            {
                Destroy(wood[i].gameObject);
            }
            for (int i = 0; i < stoneforcraft; i++)
            {
                Destroy(stone[i].gameObject);
            }
            Instantiate(stoneaxeprefab, transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.Log("Not Enough Materials");
        }
    }
    private List<Item> GetWood()
    {
        return gameObject.GetComponentsInChildren<Item>().Where(i => i.GetItemName() == "Wood").ToList();
    }
    private List<Item> GetStone()
    {
        return gameObject.GetComponentsInChildren<Item>().Where(i => i.GetItemName() == "Stone").ToList();
    }
}
