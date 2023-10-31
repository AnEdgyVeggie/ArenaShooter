using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Rigidbody _rigidbody;

    [SerializeField]
    GameObject _impactParticle;

    [SerializeField]
    float _speed = 20f;

    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
       _rigidbody.AddRelativeForce(new Vector3(_speed * Time.deltaTime, 0, 0) , ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "DragonHead")
        {
            Destroy(_rigidbody);
            Instantiate(_impactParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
