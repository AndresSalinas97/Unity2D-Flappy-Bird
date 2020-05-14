using System.Collections;
using UnityEngine;

# pragma warning disable 649  // To disable SerializeField warnings

/// <summary>
/// This class handles the spawn of new tube pairs.
/// </summary>
public class TubePairSpawner : MonoBehaviour
{
    /// <summary>
    /// Minimum value for the random y initial position of the tube pair.
    /// </summary>
    private const float MIN_INIT_Y = -1.5f;

    /// <summary>
    /// Maximum value for the random y initial position of the tube pair.
    /// </summary>
    private const float MAX_INIT_Y = 2.5f;

    /// <summary>
    /// Initial x position for the tube pair.
    /// </summary>
    private const float INIT_X = 6;

    /// <summary>
    /// Initial z position for the tube pair.
    /// </summary>
    private const float INIT_Z = 0;

    /// <summary>
    /// Time (in seconds) to wait before spawning a new tube pair.
    /// </summary>
    private const float TIME_GAP = 1.7f;

    /// <summary>
    /// Time (in seconds) it takes for the first tube pair to be spawned.
    /// </summary>
    private const float FIRST_TUBE_DELAY = 0.1f;

    /// <summary>
    /// The TubePair object.
    /// </summary>
    [SerializeField] GameObject tubePair;

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        EventsManager.instance.OnGameStarted += StartSpawning;
        EventsManager.instance.OnGameOver += StopSpawning;
    }

    /// <summary>
    /// OnDestroy is called when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        EventsManager.instance.OnGameStarted -= StartSpawning;
        EventsManager.instance.OnGameOver -= StopSpawning;
    }

    /// <summary>
    /// Starts the Spawn coroutine.
    /// </summary>
    private void StartSpawning()
    {
        StartCoroutine("Spawn");
    }

    /// <summary>
    /// Stops the Spawn coroutine.
    /// </summary>
    private void StopSpawning()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Spawns a new TubePair every TIME_GAP seconds.
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(FIRST_TUBE_DELAY);

        while (true)
        {
            float init_y = Random.Range(MIN_INIT_Y, MAX_INIT_Y);

            Instantiate(
                tubePair,
                new Vector3(INIT_X, init_y, INIT_Z),
                Quaternion.identity);

            yield return new WaitForSeconds(TIME_GAP);

            yield return null;
        }
    }
}
