using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerContrroler : MonoBehaviour
{
    [SerializeField]
    private GameObject woodsmaterials;

    [SerializeField]
    private GameObject stonematerials;


    private Rigidbody player;

    private const int SPEED = 15;


    private void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();  
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            AddMaterials(1, 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            AddForceToPlayer(new Vector3(x: 0, y: 0, z: SPEED));
        }
        if (Input.GetKey(KeyCode.S))
        {
            AddForceToPlayer(new Vector3(x: 0, y: 0, z: -SPEED));
        }
        if (Input.GetKey(KeyCode.A))
        {
            AddForceToPlayer(new Vector3(x: -SPEED, y: 0, z: 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            AddForceToPlayer(new Vector3(x: SPEED, y: 0, z: 0));
        }
    }
    private void AddMaterials(int _woodmaterials, int _stonematerials)
    {
        for (int i = 0; i < _woodmaterials; i++)
        {
            Instantiate(woodsmaterials, transform);
        }
        for (int i = 0; i < _stonematerials; i++)
        {
            Instantiate(stonematerials, transform);
        }
    }
    public void AddForceToPlayer(Vector3 vector3)
    {
        player.AddForce(vector3);
    }
}
