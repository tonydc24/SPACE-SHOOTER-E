using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndRetreatAI : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float speed;

    [SerializeField]
    float stopDistance;

    [SerializeField]
    float retreatDistance;

   

    [Header("Fire")]
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float shootInterval;

    [SerializeField]
    float bulletLifeTime;

    [SerializeField]
    float fireTimeout;

    [SerializeField]
    float nextShootTime;

    [SerializeField]
    string fireSoundSFX;

    Rigidbody2D _rigidbody;

    float _fireTimer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(_rigidbody.position, target.position);

        if (distance > stopDistance)
        {
            _rigidbody.position =
                Vector2.MoveTowards(_rigidbody.position, target.position, speed * Time.fixedDeltaTime);
        }
        else if (distance < retreatDistance)
        {
            _rigidbody.position =
                Vector2.MoveTowards(_rigidbody.position, target.position, -speed * Time.fixedDeltaTime);
        }
        else if (distance < stopDistance && distance > retreatDistance)
        {
            _rigidbody.position = this._rigidbody.position;
        }

        transform.right = target.position - transform.position;

    }

    //FIRE TO PLAYER => 40 PUNTOS

    void Start()
    {
        nextShootTime = Time.time + shootInterval;
    }

    void Update()
    {
        if (Time.time > nextShootTime)
        {
            HandleFire();
            nextShootTime = Time.time + shootInterval;
        }
    }

    private void HandleFire()
    {
        _fireTimer -= Time.deltaTime;

        GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);

        Vector2 direction = (firePoint.position - transform.position).normalized;

        BulletController controller = bullet.GetComponent<BulletController>();
        controller.SetDirection(direction);

        Destroy(bullet, bulletLifeTime);
        _fireTimer = fireTimeout;
    }
}
