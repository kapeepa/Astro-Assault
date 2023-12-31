using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    float speed = 40;
    float duration = 3.5f;

    private void Start()
    {
        transform.Translate(0, 9.2f, 0, Space.World);
        transform.Translate(0.3f, 0, 1.4f, Space.Self);
        Destroy(this.gameObject, duration);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
