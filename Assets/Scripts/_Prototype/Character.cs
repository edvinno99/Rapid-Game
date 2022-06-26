using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public int health = 10;
    public TMP_Text healthBar;

    public int row;

    private void Start()
    {
        healthBar.text = health.ToString();

    }

    public void TakeDamage(int _dmg)
    {
        health -= _dmg;
        healthBar.text = health.ToString();
    }
}
