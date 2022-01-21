// —крипт, управл€ющий состо€нием верхней карты.

using UnityEngine;

public class CardActive : MonoBehaviour
{
    [SerializeField] private GameObject cardTop;
    [SerializeField] private Sprite image;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }
    private void OnMouseDown()
    {
        Debug.Log("1 " + cardTop.activeSelf);
        if (cardTop.activeSelf)
        {
            cardTop.SetActive(false);
            Debug.Log("2 " + cardTop.activeSelf);
        }
    }
}
