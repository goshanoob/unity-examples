// Сценарий перемещения мишени-врага и стрельбы шарами .

using UnityEngine;
public class TargetMoving : MonoBehaviour
{
    // Расстояние до препятствия для смены направления движения.
    public float minDistance = 1f;
    // Скорость движения мишени.
    public float targetSpeed = 5f;
    // Размер мишени.
    public float targetSize = 1f;

    // Сериализованное поле для выбора префаба огненного шара для стрельбы.
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Update()
    {
        // Минимальное и максимальное значения случайного угла мены направления движения цели.
        float minAngle = -110, maxAndle = 110;
        // Если впереди препятствие (игрок или стена).
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
            // Если впереди игрок, и шар еще не выпущен.
            if(hitInfo.transform.gameObject.GetComponent<Player>() != null && _fireball == null)
            {
                // Выпустить огненный шар.
                castFireball();
            }
            // Если препятствие близко.
            if (hitInfo.distance  < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    private void castFireball()
    {
        // Создать экземпляр шара.
        _fireball = Instantiate(fireballPrefab);
        //Vector3 pos = transform.position;
        //pos.z *= 1.5f;
        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
        _fireball.transform.rotation = transform.rotation;
    }
}
