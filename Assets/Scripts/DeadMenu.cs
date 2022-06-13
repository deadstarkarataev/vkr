using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    public GameObject deadMenuUI;
    // Start is called before the first frame update
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        deadMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
