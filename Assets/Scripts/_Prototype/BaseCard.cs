using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour
{
    public int barLenght;

    [Space(5)]
    public bool isInPlay;
    public int line;
    public Divider div;

    public virtual void Activated() { }
}
