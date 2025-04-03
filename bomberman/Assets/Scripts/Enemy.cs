using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float rotationSpeed;
    public float startRotationSpeed;
    public float distance;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rotationSpeed = startRotationSpeed;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

            if (hitInfo.collider.CompareTag("Player"))
            {
                rotationSpeed = 0;
            }
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }
    }
}
