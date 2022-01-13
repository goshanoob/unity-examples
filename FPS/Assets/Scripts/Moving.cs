using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float horizontalSensitivity = 3f;
    public float verticalSensitivity = 3f;
    // Максимальная высота прыжка.
    private const float maxJump = 1f;
    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
    }
    void Update()
    {
        float frameTime = Time.deltaTime;
        // Величины перемещения вдоль координатных осей с учетом времени между кадрами.
        float forwardMoving = Input.GetAxis("Vertical") * horizontalSensitivity * frameTime,
              sideMoving = Input.GetAxis("Horizontal") * verticalSensitivity * frameTime,
              jump = Input.GetAxis("Jump") * frameTime;
        //jump = transform.position.y + jump;
        jump = Mathf.Clamp(jump, 0, maxJump);
        transform.Translate(sideMoving, jump, forwardMoving);
    }
}
