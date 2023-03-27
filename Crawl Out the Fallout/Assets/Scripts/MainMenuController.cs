using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if () 
        {
            StartButton();
        }
    }

    public void StartButton() 
    {
        Debug.Log("click");
        SceneManager.LoadScene(sceneName: "Apartment_level_One");
    }
}
