using UnityEngine;

/// <summary>
/// This class handles the bird movement and everything that comes with it
/// (playing sound effects, increasing the score and detecting game over).
/// </summary>
public class BirdFlap : MonoBehaviour
{
    /// <summary>
    /// Flap force.
    /// </summary>
    private const float FLAP_FORCE = 250;

    /// <summary>
    /// Rotation force (rotation is proportional to speed on y axis).
    /// </summary>
    private const float ROTATION_FORCE = 10;

    /// <summary>
    /// Bird's Rigidbody2D component (for movement and collisions).
    /// </summary>
    private Rigidbody2D rigidBody;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame. It handles the bird movement.
    /// </summary>
    private void Update()
    {
        if (GameStatus.instance.IsPlayerAlive())
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            // CODE FOR UNITY EDITOR & STANDALONE APPS (keyboard input)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Make bird flap
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector3.up * FLAP_FORCE);

                // Play flap sound
                SoundManager.instance.PlaySound(SoundManager.SoundClips.Flap);
            }
#elif UNITY_ANDROID || UNITY_IOS
            // CODE FOR ANDROID & iOS APPS (touchscreen input)
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // Make bird flap
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector3.up * FLAP_FORCE);

                // Play flap sound
                SoundManager.instance.PlaySound(SoundManager.SoundClips.Flap);
            }
#endif

            // Make bird rotate as it moves
            // The following "if statement" limits the rotation when in free
            // fall so the bird doesn't turn upside down
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 90 ||
                transform.eulerAngles.z > 270 && transform.eulerAngles.z < 360 ||
                rigidBody.velocity.y > 0)
            {
                // Rotation is proportional to speed on y axis
                float rotationAux = rigidBody.velocity.y * ROTATION_FORCE;
                transform.rotation = Quaternion.Euler(0, 0, rotationAux);
            }
        }
    }

    /// <summary>
    /// OnCollisionEnter2D is called when the bird collides with a tube or the
    /// floor. It raises the GameOver event and plays the Crash sound.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameStatus.instance.IsPlayerAlive())
        {
            EventsManager.instance.GameOver();

            SoundManager.instance.PlaySound(SoundManager.SoundClips.Crash);
        }
    }

    /// <summary>
    /// OnTriggerExit2D is called when the bird crossess a tube pair. It
    /// increases the score and plays the Coin sound.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameStatus.instance.IsPlayerAlive())
        {
            GameStats.instance.IncreaseScore();
             
            SoundManager.instance.PlaySound(SoundManager.SoundClips.Coin);
        }
    }
}
