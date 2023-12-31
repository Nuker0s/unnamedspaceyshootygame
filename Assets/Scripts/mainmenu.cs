using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadButton(string SceneToLoad) 
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void ToOtherMenu(GameObject obj) 
    {
        obj.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Quit() 
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        Application.Quit();
    }
}
