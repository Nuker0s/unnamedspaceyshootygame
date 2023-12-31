using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public static void LoadButton(string SceneToLoad) 
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public static void ToOtherMenu(GameObject selfparent, GameObject obj) 
    {
        obj.SetActive(true);
        selfparent.gameObject.SetActive(false);
    }
    public static void Quit() 
    {
        Application.Quit();
    }
}
