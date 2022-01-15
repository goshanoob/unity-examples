using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReaction : MonoBehaviour
{
    public float forceValue = 4000f;
    public float targetMass = 10f;
    void Start()
    {
        GetComponent<Rigidbody>().mass = targetMass;
    }
    public void ShowReactToHit(Vector3 originPoint, Vector3 hitPoint)
    {
        StartCoroutine(Die(originPoint: originPoint, hitPoint: hitPoint));
    }

    private IEnumerator Die(Vector3 originPoint, Vector3 hitPoint)
    {
        GetComponent<Rigidbody>().AddForce((forceValue * (hitPoint - originPoint).normalized));
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
