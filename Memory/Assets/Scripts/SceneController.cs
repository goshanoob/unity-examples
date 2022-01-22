// Скрипт для генерации карт на сцене.

using UnityEngine;
public class SceneController : MonoBehaviour
{
    // Количество видов карт по умолчанию.
    const int sortCount = 4;
    // Поле для добавления видов карт.
    [SerializeField] private Sprite[] cardSprites = new Sprite[sortCount];
    // Поле для ссылки на исходную карту на сцене.
    [SerializeField] private CardActive originCard;
    // [SerializeField] private GameObject card;
    // Количество рядов карт.
    public const int rowCount = 2;
    // Количество столбцов карт.
    public const int columnCount = 4;
    // Расстояние между соответствующими точками карт по горизонтали и вертикали.
    public const float offsetX = 2.5f;
    public const float offsetY = 3.5f;

    private void Start()
    {
        // Получить случайную последовательность номеров карт.
        int[] cardSet = getCardsSet();
        // Установить исходной вид карты.
        originCard.SetCard(cardSet[0], cardSprites[cardSet[0]]);
        // Положение исходной карты.
        Vector3 startPosition = originCard.transform.position;
        // Положение новой карты. Первая карта уже выложена.
        float x = startPosition.x + offsetX,
              y = startPosition.y;
        for (int i = 1, cardCount = rowCount * columnCount; i < cardCount; i++)
        {
            // Копировать исходную карту и разместить на сцене.
            CardActive newCard = Instantiate(originCard);
            newCard.transform.position = new Vector3(x, y, startPosition.z);
            // Установить вид карты.
            newCard.SetCard(cardSet[i], cardSprites[cardSet[i]]);
            // Длиннее, но то же самое.
            //card.GetComponent<CardActive>().SetCard(cardSprites[Random.Range(0, cardSprites.Length)]);
            
            // Вычислить положение новой карты.
            x += offsetX;
            // Если ряд заполнен, начать новый ряд.
            if ((i + 1) % columnCount == 0)
            {
                x = startPosition.x;
                y -= offsetY;
            }
        }
    }

    private int[] getCardsSet()
    {
        // Получить случайную последовательность карт по две одинаковые карты в наборе.
        int cardCount = 2 * sortCount;
        int[] cardSet = new int[cardCount];
        for(int i = 0; i < cardCount; i++)
        {
            cardSet[i] = i / 2;
        }
        // Поменять каждое значение в массиве с другим значением, выбранным случайно.
        for (int i = 0; i < cardCount; i++)
        {
            int randomIndex = Random.Range(0, cardCount);
            int tmp = cardSet[randomIndex];
            cardSet[randomIndex] = cardSet[i];
            cardSet[i] = tmp;
        }
        return cardSet;
    }
}
