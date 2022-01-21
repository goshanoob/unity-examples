// Скрипт, управляющий состоянием карт.

using UnityEngine;

public class CardActive : MonoBehaviour
{
    // Поле для добавленя верхней карты.
    [SerializeField] private GameObject cardTop;

    public void SetCard(Sprite image)
    {
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
