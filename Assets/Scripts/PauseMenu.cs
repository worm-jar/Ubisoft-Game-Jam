using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MenuPause : MonoBehaviour
{

    [SerializeField] private bool isPaused = false; // Permet de savoir si le jeu est en pause ou non.
    public GameObject pauseMenuObject;

    void Start()
    {

    }


    void Update()
    {
        // Si le joueur appuis sur Echap alors la valeur de isPaused devient le contraire.
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            
            Time.timeScale = 0f; // Le temps s'arrete
            PauseGame();
        }

        //else
            //pauseMenuObject.SetActive(false);
            //Time.timeScale = 1.0f; // Le temps reprend


    }

    public void PauseGame()
    {
        pauseMenuObject.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = !isPaused;
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
        CameraMovement.ChaseSequence = false;
    }

    public void QuitMenu()
    {
        Application.Quit();
    }

    /*void OnGUI()
    {
        if (isPaused)
        {

            // Si le bouton est présser alors isPaused devient faux donc le jeu reprend.
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 60, 100, 40), "Continuer"))
            {
                isPaused = false;
            }

            // Si le bouton est présser alors on ferme completement le jeu ou charge la scene "Menu Principal
            // Dans le cas du bouton quitter il faut augmenter sa postion Y pour qu'il soit plus bas
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 00, 100, 40), "Recommencer"))
            {
                // Application.Quit(); 
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 60, 100, 40), "Quitter"))
            {
                Application.Quit();
            }

        }
    }*/

}