using System.Collections;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    // Сила выстрела.
    public float hitForse = 4000f;
    // Компонет камеры.
    private Camera _camera;

    void Start()
    {
        // Инициализировать компонент камеры.
        _camera = GetComponent<Camera>();
        // Захватить указатель мыши, скрыть курсор.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        // Размер прицела.
        float size = 22;
        // Положение прицела на экране.
        float positionX = _camera.pixelWidth / 2 - size / 4,
              positionY = _camera.pixelHeight / 2 - size / 2;
        // Изобразить прицел в виде буквы "О".
        GUI.Label(new Rect(positionX, positionY, size, size), "O");
    }
    void Update()
    {
        // Если нажата первая кнопка мыши.
        if (Input.GetMouseButtonDown(0))
        {
            // Вычислить направление бросания луча.
            Vector3 raysPoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            // Бросить луч.
            Ray ray = _camera.ScreenPointToRay(raysPoint);
            RaycastHit hitInfo;
            // Если произошло попадание в произвольный объект сцены.
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Если прозошло попадание в мишень (врага).
                TargetReaction target = hitInfo.transform.gameObject.GetComponent<TargetReaction>();
                if (target != null)
                {
                    // Вызвать рекцию мишени на попадание.
                    target.ShowReactToHit(originPoint: _camera.transform.position, hitPoint: hitInfo.point, forceReaction: hitForse);
                }
                else
                {
                    // Асинхронно выполнить рекцию на промах.
                    StartCoroutine(SphereController(hitInfo.point));
                }
            }
        }
    }
    private IEnumerator SphereController(Vector3 spherePosition)
    {
        // Время сущестования отметки от выстрела.
        const float _timeForDestroy = 5f;
        // Создать в месте попадания в стену сферу и уничтожить ее через время _timeForDestroy.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = spherePosition;
        yield return new WaitForSeconds(_timeForDestroy);
        Destroy(sphere);
    }
}
