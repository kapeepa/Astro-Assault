using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public GameObject laser;


    private void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(laser, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(Random.Range(0.21f, 0.65f));
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }


}
