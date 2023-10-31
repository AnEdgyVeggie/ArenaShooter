using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballBody : MonoBehaviour
{
    [SerializeField]
    float rotation = 1800;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.left * (rotation * Time.deltaTime));
    }
}
