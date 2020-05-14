using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// This singleton class handles the score system, that is, keeps the current
/// score and saves and loads the the best score.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Name for the file where the best score will be saved.
    /// </summary>
    private const string FILE_NAME = "bestScore.dat";

    /// <summary>
    /// The one and only instance of the ScoreManager.
    /// </summary>
    public static ScoreManager instance;

    /// <summary>
    /// The current score.
    /// </summary>
    private int currentScore;

    /// <summary>
    /// The best score.
    /// </summary>
    private int bestScore;

    /// <summary>
    /// The complete file path where the best score will be saved.
    /// </summary>
    private string filePath;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts. It sets the instance value to reference this instance or
    /// destroys this object in case it's already set.
    /// </summary>
    private void Awake()
    {
        if (ScoreManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ScoreManager.instance = this;
        }
    }

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        EventsManager.instance.OnGameStarted += ResetScore;
        EventsManager.instance.OnTubesCrossed += IncreaseScore;

        filePath = Application.persistentDataPath + "/" + FILE_NAME;

        LoadBestScore();
    }

    /// <summary>
    /// OnDestroy is called when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        EventsManager.instance.OnTubesCrossed -= IncreaseScore;
        EventsManager.instance.OnGameStarted -= ResetScore;
    }

    /// <summary>
    /// Returns the current score.
    /// </summary>
    public int GetCurrentScore()
    {
        return currentScore;
    }

    /// <summary>
    /// Returns the best score.
    /// </summary>
    public int GetBestScore()
    {
        return bestScore;
    }

    /// <summary>
    /// Increases the current score.
    /// </summary>
    private void IncreaseScore()
    {
        currentScore++;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            SaveBestScore();
        }
    }

    /// <summary>
    /// Resets the current score.
    /// </summary>
    private void ResetScore()
    {
        currentScore = 0;
    }

    /// <summary>
    /// Loads the best score from the file.
    /// </summary>
    private void LoadBestScore()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            bestScore = (int)bf.Deserialize(file);

            file.Close();
        }
        else
        {
            bestScore = 0;
        }
    }

    /// <summary>
    /// Saves the best score to the file.
    /// </summary>
    private void SaveBestScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(filePath, FileMode.Create);

        bf.Serialize(file, bestScore);

        file.Close();
    }
}
