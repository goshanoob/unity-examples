// �������� ��������� ��������� ����.

using UnityEngine;
public class Fireball : MonoBehaviour
{
    // �������� ����������� ��������� ����.
    public float speed = 10f;
    // ����, ��������� �����.
    public float damage = 1;
    void Update()
    {
        // ����������� �������� ��� � ��������� �� ������������������.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��������� ������������ ����.
        // ���� ��� ����� � ������.
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().Health -= damage;
        }
        Destroy(gameObject);
    }
}
