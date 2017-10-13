using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour
{

    public Transform target;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }


    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
