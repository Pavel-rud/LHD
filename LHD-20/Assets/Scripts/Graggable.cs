using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graggable : MonoBehaviour
{
    bool _moveProduct;
    GameObject _product;
    bool _keyPressed;
    Vector3 _start;

    public GameObject Menu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "product")
        {
            Debug.Log(other.gameObject.tag);
            _moveProduct = true;
            _product = other.gameObject;
            transform.Find("Hand").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "product")
        {
            _product.GetComponent<Rigidbody>().isKinematic = false;
            _moveProduct = false;
            _product = null;

            transform.Find("Hand").gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if (!Menu.activeSelf)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _keyPressed = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                _keyPressed = true;
                _start = transform.position;
            }

            if (_keyPressed && _moveProduct)
            {
                _product.transform.position = _product.transform.position + this.transform.position - _start;
                _product.GetComponent<Rigidbody>().isKinematic = true;
                _start = transform.position;
            }
            else if (_product)
                _product.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
