using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject camerFollow, spectatorCamera;

    [SerializeField]
    private Text damagetext;

    [SerializeField]
    private Slider healthSlider;


    private const int MAXHEALTH = 100;

    private int currentHealth = default, damage = default;

    void Start()
    {
        currentHealth = MAXHEALTH;
    }
    void Update()
    {
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
            Isdead();
        else
            damagetext.text = currentHealth.ToString();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            currentHealth -= damage;
        /*If we have Component Enemy
        if (other.gameObject.GetComponent<Enemy>() != null)
            currentHealth -= damage;
        */
    }
    private bool Isdead()
    {
        CarDestroying();
        SetSpectatorMode();
        return true;
    }
    private void CarDestroying()
    {
        Destroy(gameObject);
    }
    private void SetSpectatorMode()
    {
        spectatorCamera.SetActive(true);
        camerFollow.SetActive(false);
    }
}