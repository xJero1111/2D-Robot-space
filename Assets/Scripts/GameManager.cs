using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject technologicalEndingPanel;
    [SerializeField] private GameObject naturalEndingPanel;
    [SerializeField] private GameObject grayEndingPanel;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraFollowSmooth cameraFollowSmooth;

    private bool isGameEnded = false;

    // Update is called once per frame
    private void Update()
    {
        //si el juego terminó, permitimos reiniciar con la tecla R
        if (isGameEnded && Input.GetKeyDown(KeyCode.R))
        {
            RestartCurrentScene();
        }
    }

    public void EndGame(GameResult gameResult)
    {
        if (isGameEnded)
        {
            return;
        }

        isGameEnded = true;

        Time.timeScale = 0f;
        DisablePlayerControl();
        ShowEndingPanel(gameResult);
    }

    public void EndGrayEnding()
    {
        EndGame(GameResult.Gray);
    }

    void RestartCurrentScene()
    {
        //aseguramos que el tiempo vuelva a la normalidad antes de recargar la escena
        Time.timeScale = 1f;

        //recargamos la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void DisablePlayerControl()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        if (cameraFollowSmooth != null)
        {
            cameraFollowSmooth.enabled = false;
        }
    }

    void ShowEndingPanel(GameResult gameResult)
    {
        if (technologicalEndingPanel != null) technologicalEndingPanel.SetActive(false);
        if (naturalEndingPanel != null) naturalEndingPanel.SetActive(false);
        if (grayEndingPanel != null) grayEndingPanel.SetActive(false);

        if (gameResult == GameResult.Technological && technologicalEndingPanel != null)
        {
            technologicalEndingPanel.SetActive(true);
        }
        else if (gameResult == GameResult.Natural && naturalEndingPanel != null)
        {
            naturalEndingPanel.SetActive(true);
        }
        else if (gameResult == GameResult.Gray && grayEndingPanel != null)
        {
            grayEndingPanel.SetActive(true);
        }
    }
}