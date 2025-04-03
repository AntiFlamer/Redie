using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private float lifetime;
    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hit)
        {
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > 5)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Diðer nesnelerle çarpýþma kontrolleri
        if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            hit = true;
            boxCollider.enabled = false; // Collider'ý kapat
            anim.SetTrigger("explode");
            Debug.Log("Explode trigger set");
        }
        else if (collision.CompareTag("Enemy"))
        {
            hit = true;
            boxCollider.enabled = false; // Collider'ý kapat
            anim.SetTrigger("explode");
            Debug.Log("Explode trigger set");
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }


    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction) 
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX,
            transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
