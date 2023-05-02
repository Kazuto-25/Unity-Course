using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;
    private GameManagerP5 gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerP5>();
    }

    public void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
    
}
