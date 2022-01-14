using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Moving")]

public class Moving : MonoBehaviour
{
    // „увствительность к перемещению (скорость перемещени€).
    public float speed = 6f;
    //  омпонент контроллер персонажа.
    private CharacterController _character;
    public float gravity = -9.8f;
    private void Start()
    {
        _character = GetComponent<CharacterController>();
    }
    void Update()
    {
        // ¬рем€ между кадрами (врем€ кадра).
        float frameTime = Time.deltaTime;
        // ¬еличины перемещени€ вдоль координатных осей с учетом времени между кадрами.
        float forwardMoving = Input.GetAxis("Vertical") * speed * frameTime,
              sideMoving = Input.GetAxis("Horizontal") * speed * frameTime;
        Vector3 motion = new Vector3(sideMoving, 0, forwardMoving);
        // ќграничить длину вектора перемещени€ при движении по диагонали.
        motion = Vector3.ClampMagnitude(motion, speed);
        // ѕеревод вектора перемещени€ в абсолютную систему координат.
        motion = transform.TransformDirection(motion);
        // ƒобавить силу т€жести.
        motion.y = gravity;
        _character.Move(motion);
    }
}