using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFireball : MonoBehaviour
{
    public GameObject projectile;
    public float projectileLifetime = 1.0f; // Waktu hidup proyektil dalam detik

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mendapatkan input sumbu horizontal dan vertikal
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Menentukan arah tembakan berdasarkan input sumbu horizontal dan vertikal
            if (horizontalInput > 0)
            {
                // Menghadap ke kanan
                ShootProjectile(new Vector2(5.0f, 0.0f));
            }
            else if (horizontalInput < 0)
            {
                // Menghadap ke kiri
                ShootProjectile(new Vector2(-5.0f, 0.0f));
            }
            else if (verticalInput > 0)
            {
                // Menghadap ke atas
                ShootProjectile(new Vector2(0.0f, 5.0f));
            }
            else if (verticalInput < 0)
            {
                // Menghadap ke bawah
                ShootProjectile(new Vector2(0.0f, -5.0f));
            }

            
        }
    }

    void ShootProjectile(Vector2 velocity)
    {
        GameObject fireball = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();

        fireballRb.velocity = velocity;

         if (velocity.x > 0.0f)
        {
            fireball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }
        else if (velocity.x < 0.0f)
        {
            fireball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
        else if (velocity.y > 0.0f)
        {
            fireball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else if (velocity.y < 0.0f)
        {
            fireball.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -180.0f);
        }

        // Menjalankan coroutine untuk menghancurkan proyektil setelah waktu tertentu
        StartCoroutine(DestroyProjectileAfterDelay(fireball, projectileLifetime));
    }

    IEnumerator DestroyProjectileAfterDelay(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(projectile);
    }
}
