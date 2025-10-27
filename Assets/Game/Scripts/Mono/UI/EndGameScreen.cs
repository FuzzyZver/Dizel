using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;

    public void SetScore(int score)
    {
        _textScore.text = $"Total score{score.ToString()}";
    }

    public void RestartLevel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
