using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float dropDistance = 0.5f;
    public float boundX = 7f;

    public GameObject enemyBulletPrefab;
    public float minShootInterval = 1.5f;
    public float maxShootInterval = 4f;

    private int direction = 1;
    private float shootTimer;

    void Start()
    {
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        if (transform.position.x > boundX)
        {
            direction = -1;
            transform.position += Vector3.down * dropDistance;
        }
        else if (transform.position.x < -boundX)
        {
            direction = 1;
            transform.position += Vector3.down * dropDistance;
        }

        if (transform.childCount == 0 && GameManager.instance != null)
        {
            GameManager.instance.Win();
        }

        if (transform.position.y < -3f && GameManager.instance != null)
        {
            GameManager.instance.Lose();
        }

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShootRandom();
            shootTimer = Random.Range(minShootInterval, maxShootInterval);
        }
    }

    void ShootRandom()
    {
        if (enemyBulletPrefab == null) return;
        if (transform.childCount == 0) return;

        int randomIndex = Random.Range(0, transform.childCount);
        Transform child = transform.GetChild(randomIndex);

        Enemy enemy = child.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Shoot();
        }
    }
}
