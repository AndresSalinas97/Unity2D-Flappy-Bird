using UnityEngine;

/// <summary>
/// Handles the tube pair movement and destruction.
/// </summary>
public class TubePairMovement : MonoBehaviour
{
    /// <summary>
    /// The speed of the tube pair.
    /// </summary>
    private const float SPEED = 3f;

    /// <summary>
    /// The minimum value of x below which the tube pair will be destroyed.
    /// </summary>
    private const float MIN_X = -5.5f;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // Only moves if the player is alive
        if (PlayerStatusManager.instance.IsPlayerAlive())
        {
            transform.position += Vector3.left * SPEED * Time.deltaTime;

            if (transform.position.x < MIN_X)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
