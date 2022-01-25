using UnityEngine;
using UnityEditor;

/// <summary>
/// Класс, описывающий перемещения подвижной платформы.
/// </summary>
public class MovingPlatform : MonoBehaviour
{
    // Скорость движения платформы.
    [SerializeField] private float speed = 2f;
    [SerializeField] private float minPostition = 6;
    [SerializeField] private float maxPostition = 6;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime * direction);
        Vector3 currentPosition = transform.position;
        if (currentPosition.x > maxPostition || currentPosition.x < minPostition)
        {
            direction *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(maxPostition, 0, 0));
    }
}
