using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // �������� �������� ������ �������������� �\��� ������������ ����.
    public enum RotationAxes
    {
        rotateX, rotateY, rotateXAndY
    }
    // ��� ��������.
    public RotationAxes axes = RotationAxes.rotateXAndY;
    // ���������������� �������� ������ �������������� � ������������ ����.
    public float horizontalSensitivity = 9f,
                 verticalSensitivity = 9f;
    // ����������� � ������������ ���� �������� ������ �������������� ���.
    public float minHorizontalAngle = -30,
                 maxHorizontalAngle = 45;
    // ������� ������ �������������� � ������������ ����.
    private float _angleXValue = 0, _angleYValue = 0;

    private void Start()
    {
        // ��������� ����������� ���������� �����.
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
        //axes = RotationAxes.rotateXAndY;
    }

    void Update()
    {
        // ��������� �������� ������ �������������� ���.
        float deltaXValue = Input.GetAxis("Mouse Y") * horizontalSensitivity;
        // ��������� �������� ������ ������������ ���.
        float deltaYValue = Input.GetAxis("Mouse X") * verticalSensitivity;
        if (axes == RotationAxes.rotateX)
        {
            // �������� ������� ���� �������� ������ �������������� ���.��
            UpdateXAngle(deltaXValue);
            // ������������� ������� ���� �������� ������ ������������ ���.
            //_angleYValue = transform.localEulerAngles.y;
        }
        else if (axes == RotationAxes.rotateY)
        {
            // ������������� ������� ���� �������� ������ �������������� ���.
            //_angleXValue = transform.localEulerAngles.x;
            // �������� ������� ���� �������� ������ ������������ ���.
            UpdateYAngle(deltaYValue);
        }
        else
        {
            UpdateXAngle(deltaXValue);
            UpdateYAngle(deltaYValue);
        }
        // �������� ����������.
        transform.localEulerAngles = new Vector3(_angleXValue, _angleYValue, 0);
    }

    private void UpdateXAngle(float delta)
    {
        // �������� ������� ���� �������� ������ �������������� ��� �� �������� delta.
        // ���������, �.�. ������� ��������� ����� - ����������� �������������� �������� ��������� � ��������� �������� ����� (� ������� �� ����������� �������� ����).
        _angleXValue -= delta;
        // ��������� ����������� � ���� �������� ������ �������������� ���.
        _angleXValue = Mathf.Clamp(_angleXValue, minHorizontalAngle, maxHorizontalAngle);
    }

    private void UpdateYAngle(float delta)
    {
        // �������� ������� ���� �������� ������ ������������ ��� �� �������� delta.
        // ��������, �.�. ����������� ����������� ��������� � ������������ �������� ����.
        _angleYValue += delta;
    }
}
