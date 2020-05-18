using UnityEngine;

/// <summary>
/// This class handles the bird movement and everything that comes with it
/// (playing the sound effects, detecting when the bird crosses a tube pair or
/// crashes and raising the corresponding events).
/// </summary>
public class FlappyBirdMovement : MonoBehaviour
{
    /// <summary>
    /// Flap force.
    /// </summary>
    private const float FLAP_FORCE = 250;

    /// <summary>
    /// Rotation force (rotation is proportional to the speed on the y axis).
    /// </summary>
    private const float ROTATION_FORCE = 10;

    /// <summary>
    /// Bird's Rigidbody2D component (for movement and collisions).
    /// </summary>
    private Rigidbody2D rigidBody;

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // If the player is alive, allow the user to make the bird flap
        if (PlayerStatusManager.instance.IsPlayerAlive())
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            // CODE FOR UNITY EDITOR & STANDALONE APPS (keyboard input)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BirdFlap();
            }
#elif UNITY_ANDROID || UNITY_IOS
            // CODE FOR ANDROID & iOS APPS (touchscreen input)
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                BirdFlap();
            }
#endif
        }

        BirdRotate();
    }

    /// <summary>
    /// Makes the bird flap and plays the flap sound.
    /// </summary>
    private void BirdFlap()
    {
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(Vector3.up * FLAP_FORCE);

        SoundManager.instance.PlaySound(SoundManager.SoundEffect.Flap);
    }

    /// <summary>
    /// Makes the bird rotate as it moves so it looks more natural.
    /// </summary>
    private void BirdRotate()
    {
        // Limit the rotation when in free fall so the bird doesn't turn upside down
        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 90 ||
            transform.eulerAngles.z > 270 && transform.eulerAngles.z < 360 ||
            rigidBody.velocity.y > 1)
        {
            // Rotation is proportional to the speed on the y axis
            float rotationAux = rigidBody.velocity.y * ROTATION_FORCE;
            transform.rotation = Quaternion.Euler(0, 0, rotationAux);
        }
    }

    /// <summary>
    /// OnCollisionEnter2D is called when the bird collides with a tube or the
    /// floor. It raises the GameOver event and plays the Crash sound.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the player is alive so it is only run once
        if (PlayerStatusManager.instance.IsPlayerAlive())
        {
            EventsManager.instance.GameOver();

            SoundManager.instance.PlaySound(SoundManager.SoundEffect.Crash);
        }
    }

    /// <summary>
    /// OnTriggerExit2D is called when the bird crossess a tube pair. It
    /// increases the score and plays the Coin sound.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Only detects the cross if the player is alive
        if (PlayerStatusManager.instance.IsPlayerAlive())
        {
            EventsManager.instance.TubesCrossed();
             
            SoundManager.instance.PlaySound(SoundManager.SoundEffect.Coin);
        }
    }
}
