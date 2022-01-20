// Скрипт постоянного движения вдоль горизонтальной линии.

using UnityEngine;
public class GoLine : MonoBehaviour
{
    // Минимальное и максимальное положения перемещения объекта.
    public float minPosition = -10f;
    public float maxPosition = 10f;
    // Скорость перемещения.
    public float speed = 3f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        float currentPosition = transform.position.z;
        // Изменить направление, если вышли за границы перемещения.
        if(currentPosition >= maxPosition || currentPosition <= minPosition) {
            speed = -speed;
        }
    }
}
