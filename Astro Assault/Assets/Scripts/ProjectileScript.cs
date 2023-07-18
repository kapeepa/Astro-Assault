using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [Range(1, 80)] public float speed;
    [Range(0, 1)] public float duration;

    private void Start()
    {
        Destroy(this.gameObject, duration);
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.Self);
    }
}
