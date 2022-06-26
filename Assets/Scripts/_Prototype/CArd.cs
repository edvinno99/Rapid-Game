using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CArd : EventTrigger
{
    private bool dragging;
    BaseCard card;

    public Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        card = GetComponent<BaseCard>();
    }

    public void Update()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;

       Divider div = GameHandler.Instance.GetClosestDivider();

        if (div.pos + card.barLenght > 11)
        {
            transform.position = startPos;

            return;
        }

        card.isInPlay = true;
        card.div = div;
        transform.position = div.transform.position;
        card.line = div.pos;

        


    }


}

