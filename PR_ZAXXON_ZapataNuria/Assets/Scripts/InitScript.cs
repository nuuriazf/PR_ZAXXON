using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitScript : MonoBehaviour
{
   
    /*---------------------------
    //------VARIABLES GLOBALES
    ------------------------------*/
    public float naveSpeed;

    //Variable que indica el nivel
    public int levelGame;

    //Puntuaci�n
    public float score;

    //Velocidad m�xima
    [SerializeField] float maxSpeed;

    //�Estoy vivo?
    bool alive;

    //UI
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    

    // Start is called before the first frame update
    void Start()
    {
        naveSpeed = 30f;
        levelGame = 0;
        //Obtengo la escena en la que estoy y si es la de juego pongo el score a 0
        
       

        maxSpeed = 100f;
        alive = true;

        float tiempoPasado = Time.time;

        scoreText.text = score + " mts.";
    }

    // Update is called once per frame
    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 1)
        {
            score = 0;
        }
        if (naveSpeed < maxSpeed && alive == true)
        {
            naveSpeed += 0.02f;
        }

        float tiempo = Time.time;
        //print(Mathf.Round(tiempo));

        score = Mathf.Round(tiempo) * naveSpeed;
        scoreText.text = Mathf.Round(score) + " mts.";
        levelText.text = "NIVEL: " + levelGame.ToString();
        if (score > 0 && score < 1000)
        {
            levelGame = 1;
        }
        else if (score > 1000 && score < 2000)
        {
            levelGame = 2;
        }
        else
        {
            levelGame = 3;
        }
    }

    //Morirse
    public void Morir()
    {
        print("Me he muerto");
        alive = false;
        naveSpeed = 0f;
        InstanciadorObstaculo instanciadorObst = GameObject.Find("InstanciadorObst").GetComponent<InstanciadorObstaculo>();
        instanciadorObst.SendMessage("Parar");

        
    }
}