using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float launchForce = 10f;
    public float maxLaunch = 10f;
    public float maxSpeed = 10f;
    public GameObject arrowPrefab;

    private Rigidbody2D rb;
    private Vector2 dragStartWorldPosition;
    private GameObject arrowInstance;
    private bool canLaunch = true;
    private bool isColliding = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool IsColliding()
    {
        return rb.IsTouchingLayers(); // No arguments means any layer
    }

    void Update()
    {
        isColliding = IsColliding();

        Debug.Log(isColliding + " " + canLaunch);

        if (!canLaunch && !isColliding)
        {
            canLaunch = true;
        }

        if (!canLaunch && isColliding)
        {
            canLaunch = true;
        }

        if (arrowInstance != null)
        {
            arrowInstance.transform.position = transform.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            dragStartWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (arrowPrefab != null)
            {
                arrowInstance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 launchDirection = (currentMouseWorldPosition - dragStartWorldPosition).normalized;

            if (arrowInstance != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePosition - transform.position).normalized;
                arrowInstance.transform.right = direction;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (arrowInstance != null)
            {
                Destroy(arrowInstance);
            }

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

            if (isColliding && canLaunch)
            {

                rb.velocity = direction * launchForce;
                if (rb.velocity.magnitude > maxLaunch)
                {
                    rb.velocity = rb.velocity.normalized * maxLaunch;
                }
                canLaunch = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // Check if the rigidbody's velocity magnitude exceeds the maximum speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            // Cap the velocity while preserving the direction
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}