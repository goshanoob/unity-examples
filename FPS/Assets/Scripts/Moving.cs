using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Moving")]

public class Moving : MonoBehaviour
{
    // ���������������� � ����������� (�������� �����������).
    public float speed = 6f;
    // ��������� ���������� ���������.
    private CharacterController _character;
    public float gravity = -9.8f;
    private void Start()
    {
        _character = GetComponent<CharacterController>();
    }
    void Update()
    {
        // ����� ����� ������� (����� �����).
        float frameTime = Time.deltaTime;
        // �������� ����������� ����� ������������ ���� � ������ ������� ����� �������.
        float forwardMoving = Input.GetAxis("Vertical") * speed * frameTime,
              sideMoving = Input.GetAxis("Horizontal") * speed * frameTime;
        Vector3 motion = new Vector3(sideMoving, 0, forwardMoving);
        // ���������� ����� ������� ����������� ��� �������� �� ���������.
        motion = Vector3.ClampMagnitude(motion, speed);
        // ������� ������� ����������� � ���������� ������� ���������.
        motion = transform.TransformDirection(motion);
        // �������� ���� �������.
        motion.y = gravity;
        _character.Move(motion);
    }
}