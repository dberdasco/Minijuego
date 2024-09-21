using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referencia al menú de pausa en la UI

    public AudioSource gameMusic;           // AudioSource para la música normal del juego
    public AudioSource pauseMusic;          // AudioSource para la música de pausa


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
        pauseMenuUI.SetActive(false);   // Oculta el menú de pausa
        Time.timeScale = 1f;            // Restaura el tiempo a su estado normal
        isPaused = false;

        // Reanudar la música del juego
        if (gameMusic != null)
        {
            gameMusic.Play();
        }

        if (pauseMusic != null)
        {
            pauseMusic.Stop();          // Detener la música de pausa
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);    // Muestra el menú de pausa
        Time.timeScale = 0f;            // Pausa el tiempo
        isPaused = true;

        // Pausar la música del juego y reproducir la música de pausa
        if (gameMusic != null)
        {
            gameMusic.Pause();
        }

        if (pauseMusic != null)
        {
            if (!pauseMusic.isPlaying)  // Verificar si ya está sonando la música de pausa
            {
                pauseMusic.Play();
            }
        }

    }

    public void QuitGame()
    {
        // Lógica para salir del juego (esto solo funcionará en una compilación, no en el editor)
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

