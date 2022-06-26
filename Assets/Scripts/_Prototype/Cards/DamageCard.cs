using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : BaseCard
{
    public int damage;
    public override void Activated()
    {
        GameHandler.Instance.character[div.row + 2].TakeDamage(damage);
    }
}
