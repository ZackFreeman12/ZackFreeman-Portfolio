using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    private UIDocument doc;
    private Button btnNewGame;
    private Button btnQuit;
    public VisualElement settingsMenu;
    public Button settings;
    public Toggle easy;
    public Toggle normal;
    public Toggle hard;
    public Button close;


    void Awake()
    {
        doc = GetComponent<UIDocument>();
        btnNewGame = doc.rootVisualElement.Q<Button>("btnNewGame");
        btnNewGame.clicked += btnNewGameOnClicked;
        settingsMenu = doc.rootVisualElement.Q<VisualElement>("settingsMenu");
        settings = doc.rootVisualElement.Q<Button>("settings");
        close = doc.rootVisualElement.Q<Button>("close");
        easy = doc.rootVisualElement.Q<Toggle>("easy");
        normal = doc.rootVisualElement.Q<Toggle>("normal");
        hard = doc.rootVisualElement.Q<Toggle>("hard");
        btnQuit = doc.rootVisualElement.Q<Button>("btnQuit");
        btnQuit.clicked += btnQuitOnClicked;
        settings.clicked += settingsPressed;
        close.clicked += closePressed;
        
        
    }
    void Update(){
        if(easy.value){
            normal.value = false;
            hard.value = false;
        }
        if(normal.value){
            easy.value = false;
            hard.value = false;
        }
        if(hard.value){
            easy.value = false;
            normal.value = false;
        }
        
    }

    private void btnNewGameOnClicked()
    {
        AudioManager.instance.Play(0);
        AudioManager.instance.sounds[1].Stop();
        AudioManager.instance.sounds[2].Play();
        SceneManager.LoadScene("Map");
        AudioManager.instance.Play(7);
        
    }

    private void btnQuitOnClicked()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
   
    void settingsPressed(){
        AudioManager.instance.Play(0);
        settingsMenu.style.display = DisplayStyle.Flex;
    }
    public void closePressed(){
        AudioManager.instance.Play(0);
        if(easy.value){
            MainManager.instance.difficulty = 1;
        }
        if(normal.value){
            MainManager.instance.difficulty = 2;
        }
        if(hard.value){
            MainManager.instance.difficulty = 3;
        }
        settingsMenu.style.display = DisplayStyle.None;
    }
        
    
}
