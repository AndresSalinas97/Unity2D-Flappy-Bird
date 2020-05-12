using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class BirdFlap : MonoBehaviour
{
    private const float JUMP_FORCE = 250;

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
            SoundManager.instance.PlaySound(SoundManager.SoundClips.Flap);
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * JUMP_FORCE);
        }

        float rotationAux = rb.velocity.y * 10;
        transform.rotation = Quaternion.Euler(0, 0, rotationAux);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EventsManager.instance.GameOver();

        if (GameStatus.instancia.IsPlayerAlive())
        {
            SoundManager.instance.PlaySound(SoundManager.SoundClips.Crash);
        }

        GameStatus.instancia.SetPlayerAlive(false);
    }
}
