using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;

   
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Move(horizontal);
    }

    void Move(float h)
    {
        var pos = transform.position;
        pos.x += h * Time.deltaTime * m_moveSpeed;
        pos.x = Mathf.Clamp(pos.x, -7.78f, 7.78f);
        transform.position = pos;
    }

   
}
