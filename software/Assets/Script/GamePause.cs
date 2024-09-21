using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referencia al men� de pausa en la UI

    public AudioSource gameMusic;           // AudioSource para la m�sica normal del juego
    public AudioSource pauseMusic;          // AudioSource para la m�sica de pausa


    private bool isPaused = false;

    void Update()
    {
        // Detectar si el jugador pulsa la tecla Esc o P para pausar el juego
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);   // Oculta el men� de pausa
        Time.timeScale = 1f;            // Restaura el tiempo a su estado normal
        isPaused = false;

        // Reanudar la m�sica del juego
        if (gameMusic != null)
        {
            gameMusic.Play();
        }

        if (pauseMusic != null)
        {
            pauseMusic.Stop();          // Detener la m�sica de pausa
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);    // Muestra el men� de pausa
        Time.timeScale = 0f;            // Pausa el tiempo
        isPaused = true;

        // Pausar la m�sica del juego y reproducir la m�sica de pausa
        if (gameMusic != null)
        {
            gameMusic.Pause();
        }

        if (pauseMusic != null)
        {
            if (!pauseMusic.isPlaying)  // Verificar si ya est� sonando la m�sica de pausa
            {
                pauseMusic.Play();
            }
        }

    }

    public void QuitGame()
    {
        // L�gica para salir del juego (esto solo funcionar� en una compilaci�n, no en el editor)
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

