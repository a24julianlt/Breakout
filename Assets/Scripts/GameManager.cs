using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Se asocia el número de ladrillos destructibles al ID de la escena (Scene-0: 0 ladrillos, Scene-1: 28 ladrillos, Scene-2: 20 ladrillos)
    public static List<int> totalBricks = new List<int> { 0, 24, 20 };


    // Variable para llevar el control de la puntuación
    public static int Score { get; private set; } = 0;
    public static int Lives { get; private set; } = 3;


    public static void UpdateScore(int points) { Score += points; }

    public static void UpdateLives() { Lives--; }

    public static void ResetGame()
    {
        Score = 0;

        Lives = 3;

        SceneManager.LoadScene(0);
    }
}