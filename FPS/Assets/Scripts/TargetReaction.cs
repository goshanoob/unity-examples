// Сценарий поведения мишени в ответ на попадание в нее.

using System.Collections;
using UnityEngine;
public class TargetReaction : MonoBehaviour
{
    // Сила, прикладываемая к мишени по умолчанию.
    private const float _forceValue = 4000f;
    // Масса мишени.
    public float targetMass = 10f;
    void Start()
    {
        GetComponent<Rigidbody>().mass = targetMass;
    }
    public void ShowReactToHit(Vector3 originPoint, Vector3 hitPoint, float forceReaction = _forceValue)
    {
        // Вызвать реакцию мишении на попадание асинхронно.
        StartCoroutine(Die(originPoint: originPoint, hitPoint: hitPoint, forceReaction: forceReaction));
    }

    private IEnumerator Die(Vector3 originPoint, Vector3 hitPoint, float forceReaction)
    {
        // Приложить силу в точку попадания в мишень со стороны стреляющего.
        GetComponent<Rigidbody>().AddForce(forceReaction * (hitPoint - originPoint).normalized);
        // Отключить компонент перемещения цели после попадания.
        TargetMoving moving = GetComponent<TargetMoving>();
        if (moving != null)
        {
            Destroy(GetComponent<TargetMoving>());
        }
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
