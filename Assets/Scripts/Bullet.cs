using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
