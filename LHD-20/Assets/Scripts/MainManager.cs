using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public float Speed = 10;
    public float JumpSpeed = 200;
    public GameObject Cam;
    public float Sensitivity = 5;
    public float Health { get; private set; } = 100;
    float _perPizel;
    public GameObject HealthBar;

    public GameObject Menu;
    public GameObject BeginNote;

    float _vertical, _horizontal, _jump, _rotHor, _rotVer;
    Quaternion _start;
    bool _isGrounded;
    bool go = true;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground") _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground") _isGrounded = false;
    }

    void Start()
    {
        _start = transform.rotation; 
        _perPizel = transform.localScale.x / Health;
    }

    void FixedUpdate()
    {
        if (!BeginNote) go = true;
        else {
            go = !BeginNote.activeSelf;
        }

        if (!Menu.activeSelf && go)
        {
            Cursor.visible = false;
            _moveCameraAndPlayer();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Cursor.visible = true;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MinusHealth(10f);

        }

        if (Health <= 0)
        {
            transform.Find("EndScreen").gameObject.SetActive(true);
            Cursor.visible = true;
        }
    }

    void _moveCameraAndPlayer()
    {
        _rotHor += Input.GetAxis("Mouse X") * Sensitivity;
        _rotVer += Input.GetAxis("Mouse Y") * Sensitivity;

        _rotVer = Mathf.Clamp(_rotVer, -80, 60);

        Quaternion _rotY = Quaternion.AngleAxis(_rotHor, Vector3.up);
        Quaternion _rotX = Quaternion.AngleAxis(-_rotVer, Vector3.right);

        Cam.transform.rotation = _start * transform.rotation * _rotX;
        transform.rotation = _start * _rotY;


        if (_isGrounded)
        {
            _vertical = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            _horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            _jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;
            GetComponent<Rigidbody>().AddForce(transform.up * _jump, ForceMode.Impulse);
        }
        transform.Translate(new Vector3(_horizontal, 0, _vertical));
    }

    public void MinusHealth(float minus)
    {
        Health = Health - minus;
        _drawRect();
    }

    void _drawRect()
    {
        HealthBar.transform.localScale = new Vector3(Health * _perPizel, 1, 1);
    }
}
