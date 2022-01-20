using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    // Расстояние до препятствия для смены направления движения.
    public float minDistance = 1f;
    // Скорость движения мишени.
    public float targetSpeed = 5f;
    // Размер мишени.
    public float targetSize = 1f;
    void Update()
    {
        // Минимальное и максимальное значения случайного угла мены направления движения цели.
        float minAngle = -110, maxAndle = 110;
        // Если впереди препятствие.
        if (isBarrierNear())
        {
            // Повернуть мишень на случайный угол вокруг вертикальной оси для смены направления движения.
            transform.Rotate(0, Random.Range(minAngle, maxAndle), 0);
        }
        // Переместить мишень вперед вдоль оси Z.
        transform.Translate(0, 0, targetSpeed * Time.deltaTime);
    }

    private bool isBarrierNear()
    {
        // Бросить луч в форме сферы из текущего положения перемещения цели размером targetSize в положительном направлении оси Z.
        if (Physics.SphereCast(transform.position, targetSize, transform.forward, out RaycastHit hitInfo))
        {
            // Если препятствие близко.
            if (hitInfo.distance  < minDistance)
            {
                return true;
            }
        }
        return false;
    }
}
