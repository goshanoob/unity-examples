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
    }

    void Update()
    {
        // ��������� �������� ������ ������������ ���.
        float angleYValue = Input.GetAxis("Mouse X") * verticalSensitivity;
        // ��������� �������� ������ �������������� ���.
        float angleXValue = Input.GetAxis("Mouse Y") * horizontalSensitivity;
        if (axes == RotationAxes.rotateX)
        {
            float rotateY = transform.localEulerAngles.y;

            _angleXValue -= angleXValue;
            _angleXValue = Mathf.Clamp(_angleXValue, minHorizontalAngle, maxHorizontalAngle);
            transform.localEulerAngles = new Vector3(_angleXValue, rotateY, 0);

            //float rotateX = transform.localEulerAngles.x - angleXValue;
            //rotateX = Mathf.Clamp(rotateX, minHorizontalAngle, maxHorizontalAngle);
            //transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);
        }
        else if (axes == RotationAxes.rotateY)
        {
            transform.Rotate(0, angleYValue, 0);
        }
        else
        {
            _angleYValue += angleYValue;
            _angleXValue -= angleXValue;
            _angleXValue = Mathf.Clamp(_angleXValue, minHorizontalAngle, maxHorizontalAngle);
            transform.localEulerAngles = new Vector3(_angleXValue, _angleYValue, 0);
        }
    }

    // TODO: �������� ������ ��������� �������� ������. ����������� ������ ��������� �������� ��� ����� �������.
}
