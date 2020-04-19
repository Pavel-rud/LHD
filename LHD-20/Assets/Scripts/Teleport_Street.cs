using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport_Street : MonoBehaviour
{
    public GameObject All;
    public GameObject Win;
    public GameObject Lose;

    private void OnTriggerEnter(Collider other)
    {
        All.SetActive(true);
        Win.SetActive(true);
        Lose.SetActive(false);
        Cursor.visible = true;
    }
}
