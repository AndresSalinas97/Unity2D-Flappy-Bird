using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class Movimiento : MonoBehaviour
{
    private const float JUMP_FORCE = 250;

    [SerializeField] AudioSource audioSourceAleteo;
    [SerializeField] AudioSource audioSourceGolpe;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&
            GameStatus.instancia.IsPlayerAlive())
        {
            audioSourceAleteo.Play();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * JUMP_FORCE);
        }

        float rotationAux = rb.velocity.y * 10;
        transform.rotation = Quaternion.Euler(0, 0, rotationAux);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameStatus.instancia.IsPlayerAlive())
        {
            audioSourceGolpe.Play();
        }
        GameStatus.instancia.SetPlayerAlive(false);
    }
}
