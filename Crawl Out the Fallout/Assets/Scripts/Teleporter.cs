using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    private int gameStartScene = 2;

    public void OnCollisionEnter2D(Collision2D c)
    {

        SceneManager.LoadScene(gameStartScene);
    }
}