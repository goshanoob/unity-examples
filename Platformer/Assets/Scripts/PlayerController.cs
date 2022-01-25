/// <summary> 
/// Класс, описывающий поведение игрока на сцене.
/// </summary>

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Скорость перемещений персонажа.
    [SerializeField] private float speed = 1f;
    // Компоненты физики и анимации.
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator animator;
    // Компонент коллайдера персонажа.
    [SerializeField] private Collider2D playerCollider;
    // Сила прыжка.
    [SerializeField] private float jumpForce = 12f;

    private void Start()
    {
        
    }

    private void Update()
    {
        // Персонаж находится на поверхности.
        bool isGrounded = true;

        // Величина перемещения персонажа.
        float translateX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // Если компонент добавлен в редакторе, вычислить величину перемещения персонажа.
        if (body != null)
        {
            body.velocity = new Vector2(translateX, body.velocity.y);
            if(!Mathf.Approximately(translateX, 0))
            {
                transform.localScale = new Vector3(Mathf.Sign(translateX), 1, 1);
            }
        }

        // Если компонент аниматор добавлен к персонажу, изменить параметр перехода между состояниями аниматора.
        if(animator != null)
        {
            animator.SetFloat("speed", Mathf.Abs(translateX));
        }

        // Если подключен компонент коллайдера, определить стоит ли персонаж на земле.
        if (playerCollider)
        {
            isGrounded = false;
            // Нижняя точка коллайдера персонажа.
            Vector3 minPoint = playerCollider.bounds.min;
            // Верхняя точка коллайдера персонажа.
            Vector3 maxPoint = playerCollider.bounds.max;
            // Получить левый нижний угол персонажа.
            Vector2 firstCorner = new Vector2(minPoint.x, minPoint.y - 0.1f);
            // Получить правый нижний угол персонажа.
            Vector2 secondCorner = new Vector2(maxPoint.x, minPoint.y - 0.2f);
            Collider2D hit = Physics2D.OverlapArea(firstCorner, secondCorner);
            // Если коллайдеры перемекаются, то персонаж на чем-то стоит.
            if(hit != null)
            {
                isGrounded = true;
            }
        }

        // Если нажата клавиша пробел и персонаж на земле, приложить импульсную силу для прыжка вверх.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Если отсутствует перемещение и персонаж на земле, отключить кольжение (для наклонных поверхностей).
        if(translateX == 0 && isGrounded)
        {
            body.gravityScale = 0;
        } else
        {
            body.gravityScale = 1;
        }
    }
}
