// ��������, ����������� ������.

using UnityEngine;

public class Player : MonoBehaviour
{
    // ���������� ������ ������.
    private float _health = 5;

    public float Health   {
        get
        {
            return _health;
        }
        set { 
            _health = value;
            Debug.Log($"�����: {_health}");
            // ������� ���������, ���� ����� ���������.
            if (_health <= 0)
            {
                Debug.Log("����� ���������!");
            }
        }
    }

    void Start()
    {
        
    }

}
