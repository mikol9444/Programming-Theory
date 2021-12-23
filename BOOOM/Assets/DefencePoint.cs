using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefencePoint : MonoBehaviour
{
    public int lives;
    public Text liveText,gameOverText; 
        private void Start()
    {
        lives = 5;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) lives--;
        liveText.text = $"lives left: {lives}";
        if (lives == 0)
        {
            Debug.Log("GameOver!");
            
            StartCoroutine(RestartScene());
        }

    }
    private IEnumerator RestartScene()
    {
        gameOverText.text = "Game Over";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
