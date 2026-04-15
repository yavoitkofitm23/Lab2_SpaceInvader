using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;          
    public GameObject bulletPrefab;    
    public Transform firePoint;        
    public float leftBound = -8f;
    public float rightBound = 8f;

    public InputAction moveAction;
    public InputAction fireAction;

    void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }

    void Update()
    {
        float move = moveAction.ReadValue<float>();
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, leftBound, rightBound);
        transform.position = new Vector3(clampedX, transform.position.y, 0);

        if (fireAction.WasPerformedThisFrame())
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
