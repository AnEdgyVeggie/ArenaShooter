using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
    [SerializeField]
    GameObject _fireball;

    [SerializeField]
    float _spawnSpeed = 4f, _start, _startLimit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _start = Random.Range(2, _startLimit);
        StartCoroutine(StartFiring());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StartFiring()
    {
        yield return new WaitForSeconds(_start);
        StartCoroutine(ShootFire());
    }

    IEnumerator ShootFire()
    {
        while (true)
        {

            Instantiate(_fireball, transform.position, transform.rotation);
            yield return new WaitForSeconds(_spawnSpeed);

        }
    }
}
