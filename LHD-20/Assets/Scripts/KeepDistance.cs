using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{
    MainManager Manage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "people")
        {
            Manage.MinusHealth(5f);
        }
    }

    private void Start()
    {
        Manage = GetComponent<MainManager>();
    }
}
