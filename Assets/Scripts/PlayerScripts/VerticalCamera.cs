using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{

    Player _player;
    [SerializeField]
    float _sensitivity;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponentInParent<Player>();
        if (_player == null) { Debug.LogError("PLAYER IS NULL IN " + this); }
        //transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateCamera();
    }

    void CalculateCamera()
    {
        float lowerBound = 0.60f, upperBound = -0.60f;
        float verticalLook = Input.GetAxisRaw("Mouse Y");
        _sensitivity = _player.GetSensitivity() * 2;

        if (transform.rotation.x >= lowerBound && verticalLook < 0)
        {
            //Debug.LogError(transform.rotation.x);
            _sensitivity = 0;
            return;
        }
        if (transform.rotation.x <= upperBound && verticalLook > 0)
        {
            //Debug.Log(transform.eulerAngles.x);
            _sensitivity = 0;
            return;
        }
        transform.Rotate(-verticalLook * _sensitivity, 0, 0);
       
    }
}
