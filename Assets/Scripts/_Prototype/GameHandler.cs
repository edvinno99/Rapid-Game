using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public float tickDuration;

    public Divider[] dividers;

    public BaseCard[] cards;

    public Character[] character = new Character[6];


   

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] _dividers = GameObject.FindGameObjectsWithTag("Divider");

        List<Divider> _list = new List<Divider>();

        foreach(var div in _dividers)
            _list.Add(div.GetComponent<Divider>());

        dividers = _list.ToArray();
    }

    public Divider GetClosestDivider()
    {
        float currentMinDistance = Mathf.Infinity;
        int closestDivIndex = 0;
        for (int i = 0; i < dividers.Length; i++)
        {
            float dist = Vector2.Distance(dividers[i].transform.position, new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (dist < currentMinDistance)
            {
                currentMinDistance = dist;
                closestDivIndex = i;
            }
        }

        return dividers[closestDivIndex];
    }

    public void EndTurn()
    {
        StartCoroutine(TurnRoutine());
    }

    IEnumerator TurnRoutine()
    {
        RunLine(1);
        yield return new WaitForSeconds(tickDuration);
        RunLine(2);
        yield return new WaitForSeconds(tickDuration);
        RunLine(3);
        yield return new WaitForSeconds(tickDuration);
        RunLine(4);
        yield return new WaitForSeconds(tickDuration);
        RunLine(5);
        yield return new WaitForSeconds(tickDuration);
        RunLine(6);
        yield return new WaitForSeconds(tickDuration);
        RunLine(7);
        yield return new WaitForSeconds(tickDuration);
        RunLine(8);
        yield return new WaitForSeconds(tickDuration);
        RunLine(9);
        yield return new WaitForSeconds(tickDuration);
        RunLine(10);
        yield return new WaitForSeconds(tickDuration);

        NewTurn();
    }

    private void RunLine(int _line)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].isInPlay && cards[i].line + cards[i].barLenght == _line)
            {
                cards[i].Activated();
            }
        }
    }

    private void NewTurn()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = cards[i].GetComponent<CArd>().startPos;
        }
    }
}
