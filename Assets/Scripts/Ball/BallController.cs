using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    Rigidbody2D m_rigidbody;

    [SerializeField] float m_ballSpeed;
    float random;

    // Start is called before the first frame update
    void Awake()
    {

        m_rigidbody = GetComponent<Rigidbody2D>();
        m_rigidbody.AddForce(new Vector2(random, -1).normalized * m_ballSpeed);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Breakable"))
            Destroy(collision.gameObject);

        if (collision.collider.CompareTag("Player"))
        {
            Vector3 hit = collision.contacts[0].point;
            Vector3 paddleCenter = new Vector3(collision.transform.position.x, collision.transform.position.y);


            if (hit.x < paddleCenter.x)
            {
                random = -1;
                m_rigidbody.velocity = Vector2.zero;
                m_rigidbody.AddForce(new Vector2(random, -1).normalized * m_ballSpeed);
            }
            else
            {
                random = 1;
                m_rigidbody.velocity = Vector2.zero;
                m_rigidbody.AddForce(new Vector2(random, -1).normalized * m_ballSpeed);
            }

            print(random);

        }

        if (collision.collider.CompareTag("GameOver"))
        {
            GameManager.instance.GameOver(true);
            Time.timeScale = 0;
        }


    }
}
