// Скрипт для генерации карт на сцене, управления сценой.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // Поле для добавления видов карт.
    [SerializeField] private Sprite[] cardSprites = new Sprite[sortCount];
    // Поле для ссылки на исходную карту на сцене.
    [SerializeField] private CardActive originCard;
    // [SerializeField] private GameObject card;
    // Поле для выбора объекта, выводящего надпись о счете игрока.
    [SerializeField] private TextMesh scoreText;

    // Первая открытая карта и вторая открытые карты.
    private CardActive _firstOpendCard, _secondOpendCard;
    // Счет игрока.
    private int _score = 0;

    // Количество видов карт по умолчанию.
    public const int sortCount = 4;
    // Количество рядов карт.
    public const int rowCount = 2;
    // Количество столбцов карт.
    public const int columnCount = 4;
    // Расстояние между соответствующими точками карт по горизонтали и вертикали.
    public const float offsetX = 2.5f;
    public const float offsetY = 3.5f;

    // Свойство, определяющее возможность открытия следующей карты.
    public bool CanBeOpened
    {
        get
        {
            // Нельзя открыть больше двух карт.
            return _secondOpendCard == null;
        }
    }

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
        for (int i = 0; i < cardCount; i++)
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

    public void OpenCard(CardActive openCard)
    {
        // Сохранить ссылку на очередную (из двух) открытую карту.
        if (_firstOpendCard == null)
        {
            _firstOpendCard = openCard;
        }
        else
        {
            _secondOpendCard = openCard;
            // Сравнить карты.
            StartCoroutine(CheckMatches());
        }
    }

    private IEnumerator CheckMatches()
    {
        if(_firstOpendCard.CardId == _secondOpendCard.CardId)
        {
            // Увиличить счет игрока, если карты совпали.
            _score++;
            // Вывести счет на экран.
            scoreText.text = "Счет: " + _score;
        }
        else
        {
            // Скрыть несовпавшие карты.
            // Время до сокрытия несовпавших карт.
            const float showTime = 1f;
            yield return new WaitForSeconds(showTime);
            _firstOpendCard.hideCard();
            _secondOpendCard.hideCard();
        }
        // Удалить ссылки на карты при любом исходе проверки для дальнейших сравнений.
        _firstOpendCard = null;
        _secondOpendCard = null;
    }

    public void Restart()
    {
        // Перезагрузить сцену.
        SceneManager.LoadScene("MainScene");
    }
}
