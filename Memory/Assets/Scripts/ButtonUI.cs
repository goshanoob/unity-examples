// Скрипт, определяющий работу кнопки как части графического интерфейса.

using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    // Игровой объект на сцене, которому требуетс¤ послать сообщение при щелчке мыши.
    [SerializeField] private GameObject targetObject;
    // Текстовое сообщение, передаваемое выбранному объекту.
    [SerializeField] private string message;
    // Свет кнопки при наведении мыши.
    public Color buttonColor = Color.cyan;
    private void OnMouseEnter()
    {
        // Изменить цвет кнопки при наведении мыши.
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.color = buttonColor;
        }
    }
    private void OnMouseExit()
    {
        // Вернуть цвет кнопки при покидании мыши.
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        // Именить размер кнопки при нажатии на нее.
        transform.localScale *= 1.1f;
    }
    private void OnMouseUp()
    {
        // Вернуть размер кнопки при после нажатия.
        transform.localScale = Vector3.one;
        // Послать сообщение выбранному объекту, если объект выбран.
        if (targetObject != null)
        {
            // В данном случае ожидается, что message = "Restart".
            targetObject.SendMessage(message);
        }
    }
}
