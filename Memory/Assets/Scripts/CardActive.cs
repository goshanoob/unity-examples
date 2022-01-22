// Скрипт, управляющий состоянием карт.

using UnityEngine;

public class CardActive : MonoBehaviour
{
    // Поле для добавленя верхней карты.
    [SerializeField] private GameObject cardTop;
    // Свойство, хранящее номер вида карты.
    public int CardSort { get; private set; }
    public void SetCard(int cardSort, Sprite image)
    {
        CardSort = cardSort;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    private void OnMouseDown()
    {
        // Если верхняя карта видима, сделать невидимой.
        if (cardTop.activeSelf)
        {
            cardTop.SetActive(false);
        }
    }
}
