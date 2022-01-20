// Сценарий перемещения игрового объекта клавишами клавиатуры.

using UnityEngine;

// Требуется компонент игорового объекта CharacterController.
[RequireComponent(typeof(CharacterController))]
// Добавить скрипт в меню добавления компонентов.
[AddComponentMenu("Control Script/FPS Moving")]

public class Moving : MonoBehaviour
{
    // Чувствительность к перемещению (скорость перемещения).
    public float speed = 6f;
    // Компонент-контроллер персонажа.
    private CharacterController _character;
    public float gravity = -9.8f;
    private void Start()
    {
        // Инициализация контроллера персонажа.
        _character = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Время между кадрами (время кадра).
        float frameTime = Time.deltaTime;
        // Величины перемещений вдоль координатных осей с учетом времени между кадрами.
        float forwardMoving = Input.GetAxis("Vertical") * speed * frameTime,
              sideMoving = Input.GetAxis("Horizontal") * speed * frameTime;
        Vector3 motion = new Vector3(sideMoving, 0, forwardMoving);
        // Ограничить длину вектора перемещения при движении по диагонали.
        motion = Vector3.ClampMagnitude(motion, speed);
        // Представить вектор перемещения в абсолютной системе координат.
        motion = transform.TransformDirection(motion);
        // Добавить силу тяжести.
        motion.y = gravity;
        _character.Move(motion);
    }
}