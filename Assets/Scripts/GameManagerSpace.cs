using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManagerSpace : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] GameObject gamewinUI;
    //set up game over UI, disable player input for the character controller here
/*    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;*/
    [SerializeField] Slider healthUI;
    [SerializeField] PathFollower follower;
    //[SerializeField] GameObject player;
/*    [SerializeField] Camera isoCam;*/
    //skybox moment
/*    [SerializeField] Material skyboxOutside;
    [SerializeField] Material skyboxInside;
*/
    [SerializeField] FloatVariable health;

    //[SerializeField] GameObject respawn;

    [Header("Events")]
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;

    public bool winGame = false;

    public enum State
    {
        TITLE, 
        START_GAME,
        PLAY_GAME,
        GAME_OVER,
        GAME_WIN
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

/*    public int Lives {  
        get { return lives; } 
        set { 
            lives = value; 
            //livesUI.text = "Lives: " + lives.ToString(); 
        } 
    }

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            //timerUI.text = string.Format("{0:F1}", timer);
        }
    }*/

    private void OnEnable()
    {
        //scoreEvent.Subscribe(OnAddPoints);
    }

    private void OnDisable()
    {
       // scoreEvent.Unsubscribe(OnAddPoints);

    }

    void Start()
    {
        //scoreEvent.Subscribe(OnAddPoints);

    }


    void Update()
    {

        if (winGame == true)
        {
            state = State.GAME_WIN;
        }
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb = player.gameObject.GetComponent<Rigidbody>();
        switch (state)
        {
            case State.TITLE:
                //cursor edits
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //character edits
                //rb.constraints = RigidbodyConstraints.FreezeAll;
                //player.gameObject.GetComponent<Rigidbody>().constraints = rb.constraints;
                //UI edits
                titleUI.SetActive(true);
                gameUI.SetActive(false);
                gameoverUI.SetActive(false);
                gamewinUI.SetActive(false);
                //RenderSettings.skybox = skyboxOutside;
                //Lives = 3;
                //rb.constraints = RigidbodyConstraints.FreezePositionZ;

                break;
            case State.START_GAME:
                //player.gameObject.GetComponent<PhysicsCharacterController>().dead = false;
                //cursor edits
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                //character edits
                //player.gameObject.GetComponent<Rigidbody>().constraints = rb.constraints;
                //isoCam.GetComponent<Pan>().allowedPanning = true;
                //UI edits
                titleUI.SetActive(false);
                gameUI.SetActive(true);
                gameoverUI.SetActive(false);
                //Stat initializers
                //Timer = 0;
                health.value = 5;
                gameStartEvent.RaiseEvent();
                //respawnEvent.RaiseEvent(respawn);

                //RenderSettings.skybox = skyboxInside;


                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                //Timer = Timer += Time.deltaTime;


                break;
            case State.GAME_OVER:
                gameUI.SetActive(false);
                titleUI.SetActive(false);
                gamewinUI.SetActive(false);
                gameoverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.GAME_WIN:
                gameUI.SetActive(false);
                titleUI.SetActive(false);
                gamewinUI.SetActive(true);
                //gamewinUI.GetComponent<AudioSource>().Play();
                break;
        }

        healthUI.value = health.value / 5.0f;
    }

    public void OnPlayerDead()
    {
        lives--;
        state = State.GAME_OVER;
        //Timer = 0;
        //player.gameObject.GetComponent<PhysicsCharacterController>().dead = true;
        health.value = 5;
        //respawnEvent.RaiseEvent(respawn);
        
    }

    public void OnStartGame()
    {
        state = State.START_GAME;
        Debug.Log("button pressed.");
        follower.speed = 3;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }

    public void Respawn()
    {
        follower.tdistance = 0;
    }
}
