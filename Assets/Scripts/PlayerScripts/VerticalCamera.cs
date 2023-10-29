using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{

    Player _player;
    [SerializeField]
    float _sensitivity, _xRotation = 0;

    private Transform rotation;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponentInParent<Player>();
        if (_player == null) { Debug.LogError($"PLAYER IS NULL IN  {this.name.ToUpper()}"); }
        
        rotation = GetComponent<Transform>();
        if (rotation == null) { Debug.LogError($"ROTATION IS NULL IN {this.name.ToUpper() }"); }

        _sensitivity = _player.GetSensitivity() * Time.deltaTime; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateCamera();
    }

    void CalculateCamera()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y") * _sensitivity;
        float mouseX = Input.GetAxisRaw("Mouse X") * _sensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        /*  rotation.Rotate(Vector3.up * mouseX);*/

    }
}
