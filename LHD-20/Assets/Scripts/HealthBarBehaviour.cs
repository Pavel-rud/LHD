using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public float Health { get; private set; } = 100;
    float _perPizel;
    void Start()
    {
        _perPizel = transform.localScale.x / Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinusHealth(float minus)
    {
        Health = Health - minus;
        _drawRect();
    }

    void _drawRect()
    {
        Debug.Log(transform.localScale);
        transform.localScale = new Vector3(Health * _perPizel, 1, 1);
    }
}
