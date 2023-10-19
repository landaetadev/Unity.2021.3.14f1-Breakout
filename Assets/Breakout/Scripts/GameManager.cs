using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] int bricksOnLevel;
    [SerializeField] int playerLives = 3;
    public bool ballIsOnPlay;
    float gameTime; //Tiempo de duracion del juego
    bool gameStarted;
    [SerializeField] UIController uiController;

    public int BricksOnLevel {
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            if (bricksOnLevel == 0) {
                print("Game Over!");
                Destroy(GameObject.Find("Ball")); //DESTRUIR LA BOLA
                //MOSTRAR EL TIEMPO
                gameTime = Time.time - gameTime;
                print("Tiempo de juego: " + gameTime);

                //MOSTRAR PANTALLA DE GANADOR
                uiController.ActivateWinnerScreen();
                uiController.UpdateTime(gameTime); //MUESTRA EL TIEMPO FINAL EN LA UI
            }
        }
    }

    public bool GameStarted {
        get => gameStarted;
        set {
            gameStarted = value;
            gameTime = Time.time;
        }
    }

    public int PlayerLives {
        get => playerLives;
        set {
            playerLives = value;
            uiController.UpdateLives(playerLives); //ACTUALIZAR LA CANTIDAD DE VIDAS EN LA UI
            if (playerLives == 0) { //SI EL JUGADOR SE QUEDA SIN VIDAS
                uiController.ActivateLoseScreen(); //MOSTRAR PANTALLA DE PERDEDOR
                Destroy(GameObject.Find("Ball")); //DESTRUIR LA BOLA
            }
        }
    }
}