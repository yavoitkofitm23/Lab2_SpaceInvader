using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 5;
    bool invincible = false;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        GameManager.instance.UpdateHP(hp);
    }

    public void TakeDamage(int dmg)
    {
        if (invincible)
            return;

        hp = hp - dmg;
        GameManager.instance.UpdateHP(hp);

        if (hp <= 0)
        {
            GameManager.instance.Lose();
            gameObject.SetActive(false);
        }
        else
        {
            // мигание
            invincible = true;
            InvokeRepeating("Blink", 0f, 0.15f);
            Invoke("StopBlink", 1.5f);
        }
    }

    void Blink()
    {
        sr.enabled = !sr.enabled;
    }

    void StopBlink()
    {
        CancelInvoke("Blink");
        sr.enabled = true;
        invincible = false;
    }
}
