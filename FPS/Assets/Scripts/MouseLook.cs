using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // ¬арианты вращений вокруг горизонтальной и\или вертикальной осей.
    public enum RotationAxes
    {
        rotateX, rotateY, rotateXAndY
    }
    // ќсь вращени€.
    public RotationAxes axes = RotationAxes.rotateXAndY;
    // „увствительность вращени€ вокруг горизонтальной и вертикальной осей.
    public float horizontalSensitivity = 9f,
                 verticalSensitivity = 9f;
    // ћинимальный и максимальный углы вращени€ вокруг горизонтальной оси.
    public float minHorizontalAngle = -30,
                 maxHorizontalAngle = 45;
    // ѕоворот вокруг горизонтальной и вертикальной осей.
    private float _angleXValue = 0, _angleYValue = 0;

    private void Start()
    {
        // ќтключить воздействие физической среды.
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        // »зменение вращени€ вокруг вертикальной оси.
        float angleYValue = Input.GetAxis("Mouse X") * verticalSensitivity;
        // »зменение вращени€ вокруг горизонтальной оси.
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

    // TODO: ƒобавить методы получени€ поворота камеры. ‘иксировать теущие положени€ поворота при смене режимов.
}
