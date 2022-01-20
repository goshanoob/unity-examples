// Сценарий, описывающий игрока.

using UnityEngine;

public class Player : MonoBehaviour
{
    // Количество жизней игрока.
    private float _health = 5;

    public float Health   {
        get
        {
            return _health;
        }
        set { 
            _health = value;
            Debug.Log($"Жизни: {_health}");
            // Вывести сообщение, если жизни кончились.
            if (_health <= 0)
            {
                Debug.Log("Жизни кончились!");
            }
        }
    }

    void Start()
    {
        
    }

}
