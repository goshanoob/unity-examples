// Сценарий поведения огненного шара.

using UnityEngine;
public class Fireball : MonoBehaviour
{
    // Скорость перемещения огненного шара.
    public float speed = 10f;
    // Урон, наносимый шаром.
    public float damage = 1;
    void Update()
    {
        // Переместить огненный шар с поправкой на производительность.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Обработка столкновений шара.
        // Если шар попал в игрока.
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().Health -= damage;
        }
        Destroy(gameObject);
    }
}
