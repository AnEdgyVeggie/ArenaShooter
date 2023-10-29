using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _playerSpeed = 3, _lookSensitivity = 100, _jumpHeight = 1, _gravity = -9.81f;
    [SerializeField]
    bool _isGrounded = true, _canSpecialJump = false;
    Vector3 _playerVelocity;

   CharacterController _char;


    // Start is called before the first frame update
    void Start()
    {
        _char = GetComponent<CharacterController>();
        if (_char == null) { Debug.LogError("character controller IS NULL IN " + this); }
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 3f, Color.red);

        CalculateMovement();
        CalculateRotation();
        CalculateIsGrounded();
    }

    void CalculateIsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1.2f))
        {
            _canSpecialJump = false;
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }


    void CalculateMovement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveDirection = transform.TransformDirection(move);
        _char.Move(moveDirection * Time.deltaTime * _playerSpeed);

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
            StartCoroutine(SetSpecialJumpRoutine());
        }
        if (Input.GetKeyDown(KeyCode.Space) && _canSpecialJump == true)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
            _canSpecialJump = false;
        }

        _playerVelocity.y += _gravity * Time.deltaTime;
        _char.Move(_playerVelocity * Time.deltaTime);
    }

    void CalculateRotation()
    {
        float horizontalLook = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalLook * _lookSensitivity * Time.deltaTime, 0);
    }

    IEnumerator SetSpecialJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _canSpecialJump = true;
    }

    public float GetSensitivity() { return _lookSensitivity; }

}
