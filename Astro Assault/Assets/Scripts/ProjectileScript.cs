using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    float speed = 40;
    float duration = 0.75f;

    private void Start()
    {
        transform.Translate(0, 9.4f, 0, Space.World);
        transform.Translate(0.3f, 0, 1.4f, Space.Self);
        Destroy(this.gameObject, duration);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
