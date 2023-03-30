using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private int gameStartScene = 0;
    public void OnCollisionEnter2D(Collision2D c)
    {

        SceneManager.LoadScene(gameStartScene);
    }
    // Update is called once per frame
  
}
