using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;

    void Start()
    {
        //ToString converts a variable type to a string. When combining a string and other strings
        //or variables, we add a + between them. This is call string concatenation
        scoreText.text = "Score: " + score.ToString();
    }

    //updates the score by 1. We could also pass in parameters and give our collectibles individual values
    //that update the score according to the value parsed in
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
