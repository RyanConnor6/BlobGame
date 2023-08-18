using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float launchForce = 10f;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }

    void Update()
    {
        if (!canLaunch && !isColliding)
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
                float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
                arrowInstance.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (arrowInstance != null)
            {
                Destroy(arrowInstance);
            }

            Vector2 dragEndWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 launchDirection = (dragEndWorldPosition - dragStartWorldPosition).normalized;

            if (isColliding && canLaunch)
            {
                rb.velocity = launchDirection * launchForce;
                canLaunch = false;
            }
        }
    }
}