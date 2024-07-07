using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    bool isPlayerBullet;



    Rigidbody2D _rigidbody;

    Vector2 _direction;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rigidbody.velocity = _direction * speed ;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && isPlayerBullet)
        {
            CentinelController controller = other.gameObject.GetComponent<CentinelController>();
            // Implement GetPoints on CentinelController ==> 10pts Ready
            float points = controller.GetPoints();
            UIController.Instance.IncreaseScore(points);

            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Boss") && isPlayerBullet)
        {
            BossController controller = other.gameObject.GetComponent<BossController>();
            controller.TakeDamage();
        }
        else if (other.gameObject.CompareTag("Player") && !isPlayerBullet)
        {
            SpaceshipController controller = other.gameObject.GetComponent<SpaceshipController>();
            controller.Die();

            Destroy(gameObject);
        }
    }
    public void SetDirection ( Vector2 direction )
    {
        _direction = direction;
    }
}
