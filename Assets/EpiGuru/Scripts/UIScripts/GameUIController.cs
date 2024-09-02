using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private UIDocument doc;
    private VisualElement root;
    private Button pauseBut;

    public static event Action OnPause;

    private void Start()
    {
        root = doc.rootVisualElement;
        InitBut();
    }

    private void InitBut()
    {
        Button exitBut = root.Q<Button>("ExitBut");
        exitBut.clickable.clicked += () => { 
                SceneManager.LoadScene("MenuScene");
        };

        pauseBut = root.Q<Button>("PauseBut");
        pauseBut.clickable.clicked += () => { 
            OnPause?.Invoke();

            if(pauseBut.text == "PAUSE")
                pauseBut.text = "START";
            else if(pauseBut.text == "START")
                pauseBut.text = "PAUSE";
        };

        Button exitButBoard = root.Q<Button>("ExitButBoard");
        exitButBoard.clickable.clicked += () => { 
                SceneManager.LoadScene("MenuScene");
        };
    }

    public void InitMessage(string text, int score)
    {
        VisualElement gameUIBoard = root.Q<VisualElement>("GameUIBoard");
        VisualElement finalBoard = root.Q<VisualElement>("FinalBoard");
        Label messageLab = root.Q<Label>("MessageLab");
        Label scoreLabBoard = root.Q<Label>("ScoreLabBoard");

        gameUIBoard.style.display = DisplayStyle.None;
        finalBoard.style.display = DisplayStyle.Flex;
        messageLab.text = text;
        scoreLabBoard.text = score.ToString();
    }

    public void InitScore(int score)
    {
        Label scoreLab = root.Q<Label>("ScoreLab");
        scoreLab.text = score.ToString();
    }
}