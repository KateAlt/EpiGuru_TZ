using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private UIDocument doc;
    private VisualElement root;

    private void Start()
    {
        root = doc.rootVisualElement;
        InitBut();
    }

    private void InitBut()
    {
        Button startBut = root.Q<Button>("StartBut");
        startBut.clickable.clicked += () => { 
                SceneManager.LoadScene("GameScene");
            };
    }
}
