using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IInitializePotentialDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / 2; //canvas.scaleFactor;
        //rectTransform.anchoredPosition += eventData.delta * Time.deltaTime;
        //this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
    }
}

//Tip: by default unity has a threshold on drag, meaning the object starts
//following after the mouse has moved an amount in some direction.
//To avoid this and have the object move exactly under where you click,
//you need to implement the IInitializePotentialDragHandler interface and
//inside OnInitializePotentialDrag set eventData.useDragThreshold = false

//, IInitializePotentialDragHandler

//UI_Item.cs
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using TMPro;
//
//public class UI_Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
//{
//
//    private Canvas canvas;
//    private RectTransform rectTransform;
//    private CanvasGroup canvasGroup;
//    private Image image;
//    private Item item;
//    private TextMeshProUGUI amountText;
//
//    private void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        canvas = GetComponentInParent<Canvas>();
//        image = transform.Find("image").GetComponent<Image>();
//        amountText = transform.Find("amountText").GetComponent<TextMeshProUGUI>();
//    }
//
//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        canvasGroup.alpha = .5f;
//        canvasGroup.blocksRaycasts = false;
//        UI_ItemDrag.Instance.Show(item);
//    }
//
//    public void OnDrag(PointerEventData eventData)
//    {
//        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
//    }
//
//    public void OnEndDrag(PointerEventData eventData)
//    {
//        canvasGroup.alpha = 1f;
//        canvasGroup.blocksRaycasts = true;
//        UI_ItemDrag.Instance.Hide();
//    }
//
//    public void OnPointerDown(PointerEventData eventData)
//    {
//        if (eventData.button == PointerEventData.InputButton.Right)
//        {
//            // Right click, split
//            if (item != null)
//            {
//                // Has item
//                if (item.IsStackable())
//                {
//                    // Is Stackable
//                    if (item.amount > 1)
//                    {
//                        // More than 1
//                        if (item.GetItemHolder().CanAddItem())
//                        {
//                            // Can split
//                            int splitAmount = Mathf.FloorToInt(item.amount / 2f);
//                            item.amount -= splitAmount;
//                            Item duplicateItem = new Item { itemType = item.itemType, amount = splitAmount };
//                            item.GetItemHolder().AddItem(duplicateItem);
//                        }
//                    }
//                }
//            }
//        }
//    }
//
//    public void SetSprite(Sprite sprite)
//    {
//        image.sprite = sprite;
//    }
//
//    public void SetAmountText(int amount)
//    {
//        if (amount <= 1)
//        {
//            amountText.text = "";
//        }
//        else
//        {
//            // More than 1
//            amountText.text = amount.ToString();
//        }
//    }
//
//    public void Hide()
//    {
//        gameObject.SetActive(false);
//    }
//
//    public void Show()
//    {
//        gameObject.SetActive(true);
//    }
//
//    public void SetItem(Item item)
//    {
//        this.item = item;
//        SetSprite(Item.GetSprite(item.itemType));
//        SetAmountText(item.amount);
//    }
//
//}