// Сценарий упрвления ориентацией камеры при помощи мыши.

using UnityEngine;
public class MouseLook : MonoBehaviour
{
    // Варианты вращений вокруг горизонтальной и\или вертикальной осей.
    public enum RotationAxes
    {
        rotateX, rotateY, rotateXAndY
    }
    // Ось вращения.
    public RotationAxes axes = RotationAxes.rotateXAndY;
    // Чувствительность вращения вокруг горизонтальной и вертикальной осей.
    public float horizontalSensitivity = 9f,
                 verticalSensitivity = 9f;
    // Минимальный и максимальный углы вращения вокруг горизонтальной оси.
    public float minHorizontalAngle = -30,
                 maxHorizontalAngle = 45;
    // Поворот вокруг горизонтальной и вертикальной осей.
    private float _angleXValue = 0, _angleYValue = 0;

    private void Start()
    {
        // Отключить воздействие физической среды.
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
        //axes = RotationAxes.rotateXAndY;
    }

    void Update()
    {
        // Изменение вращения вокруг горизонтальной оси.
        float deltaXValue = Input.GetAxis("Mouse Y") * horizontalSensitivity;
        // Изменение вращения вокруг вертикальной оси.
        float deltaYValue = Input.GetAxis("Mouse X") * verticalSensitivity;
        if (axes == RotationAxes.rotateX)
        {
            // Изменить текущий угол поворота вокруг горизонтальной оси.ав
            UpdateXAngle(deltaXValue);
            // Зафиксировать текущий угол поворота вокруг вертикальной оси.
            //_angleYValue = transform.localEulerAngles.y;
        }
        else if (axes == RotationAxes.rotateY)
        {
            // Зафиксировать текущий угол поворота вокруг горизонтальной оси.
            //_angleXValue = transform.localEulerAngles.x;
            // Изменить текущий угол поворота вокруг вертикальной оси.
            UpdateYAngle(deltaYValue);
        }
        else
        {
            UpdateXAngle(deltaXValue);
            UpdateYAngle(deltaYValue);
        }
        // Обновить ориентацию.
        transform.localEulerAngles = new Vector3(_angleXValue, _angleYValue, 0);
    }

    private void UpdateXAngle(float delta)
    {
        // Изменить текущий угол поворота вокруг горизонтальной оси на величину delta.
        // Вычитание, т.к. система координат левая - направление положительного поворота совпадает с движением стрелики часов (в отличие от направления движения мыши).
        _angleXValue -= delta;
        // Применить ограничения к углу поворота вокруг горизонтальной оси.
        _angleXValue = Mathf.Clamp(_angleXValue, minHorizontalAngle, maxHorizontalAngle);
    }

    private void UpdateYAngle(float delta)
    {
        // Изменить текущий угол поворота вокруг вертикальной оси на величину delta.
        // Сложение, т.к. направление перемещения совпадает с направлением движения мыши.
        _angleYValue += delta;
    }
}
