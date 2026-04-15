using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyBulletPrefab;

    void Start()
    {
        // 3 ряди по 5 ворогів
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                float x = -4f + col * 2f;
                float y = 1.5f - row * 1.5f;

                GameObject e = Instantiate(enemyPrefab, transform);
                e.transform.localPosition = new Vector3(x, y, 0);
                e.name = "Enemy" + row + "_" + col;

                Enemy script = e.GetComponent<Enemy>();
                script.enemyBulletPrefab = enemyBulletPrefab;

                // верхній ряд - 3хп, середній - 2хп, нижній - 1хп
                if (row == 0)
                {
                    script.maxHP = 3;
                    script.scoreValue = 30;
                    e.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (row == 1)
                {
                    script.maxHP = 2;
                    script.scoreValue = 20;
                    e.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0f);
                }
                else
                {
                    script.maxHP = 1;
                    script.scoreValue = 10;
                    e.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }
}
