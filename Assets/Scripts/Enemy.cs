using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 1;
    int hp;
    public int scoreValue = 10;
    public GameObject enemyBulletPrefab;

    void Start()
    {
        hp = maxHP;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            hp = hp - 1;
            
            GetComponent<SpriteRenderer>().color = Color.white;
            Invoke("ResetColor", 0.1f);

            if (hp <= 0)
            {
                GameManager.instance.AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }

    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public void Shoot()
    {
        if (enemyBulletPrefab != null)
            Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }
}
