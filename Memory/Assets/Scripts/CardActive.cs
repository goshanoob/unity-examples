// Скрипт, управляющий состоянием карт.

using UnityEngine;
using System.Collections;
public class CardActive : MonoBehaviour
{
    // Поле для добавленя верхней карты.
    [SerializeField] private GameObject cardTop;
    // Ссылка на сценарий, управляющий картами на сцене.
    [SerializeField] private SceneController sceneController;
    // Свойство, хранящее номер вида карты.
    public int CardId { get; private set; }

    public void SetCard(int cardSort, Sprite image)
    {
        // Запомнить вид карты, присвоив ей идентификатор.
        CardId = cardSort;
        // Определить изображение вида карты.
        GetComponent<SpriteRenderer>().sprite = image;
    }
    private void OnMouseDown()
    {
        // Если верхняя карта видима, сделать невидимой.
        if (cardTop.activeSelf && sceneController.CanBeOpened)
        {
            // Открыть данную карту.
            cardTop.SetActive(false);
            // Сообщить контроллеру, что данная карта открыта.
            sceneController.OpenCard(this);
        }
    }

    public void hideCard()
    {
        // Закрыть данную карту.
        cardTop.SetActive(true);
    }
}
