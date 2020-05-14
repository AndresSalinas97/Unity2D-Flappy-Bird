using UnityEngine;

/// <summary>
/// This class makes the floor scroll.
/// </summary>
public class FloorScrollParallax : MonoBehaviour
{
    /// <summary>
    /// Scroll speed carefully chosen to match the tubes speed.
    /// </summary>
    private const float SPEED = 0.37f;

    /// <summary>
    /// Floor material.
    /// </summary>
    private Material material;

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // Only moves if the player is alive
        if (PlayerStatusManager.instance.IsPlayerAlive())
        {
            material.mainTextureOffset += new Vector2(Time.deltaTime * SPEED, 0);
        }
    }
}
