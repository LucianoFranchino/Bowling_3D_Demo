using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public float tiros = 0;
    public Text contTiros;
    public GameObject restartGame;
   
    
    public void Start()
    {
        FindObjectOfType<GameManager>().ContarTiros();

    }



    public void Restart()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("Bowling");
        
    }

 
}
