using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        currentDirection = new Vector3(0, 0, -speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWallNear())
        {
            currentDirection = new Vector3(Random.value, Random.value, Random.value);
        }
        transform.Translate(currentDirection.normalized * speed * Time.deltaTime);

    }

    private bool isWallNear()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetDirection = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 1);
        Ray ray = new Ray(transform.position, targetDirection);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.distance);
            if (hitInfo.distance  < 0.5)
            {
                return true;
            }
        }
        return false;
    }
}
