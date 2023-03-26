using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static pauseMenu instance;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public CamExtend CamPlayer;
    public Follow CamMecha;
    public Weapon WeaponController;
    public bool isPaused
    {
        get;
        private set;
    }


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CamPlayer.enabled = true;
        CamMecha.enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1.0f;
                isPaused = false;
                PauseMenu.SetActive(false);

            }
            else
            {
                Time.timeScale = 0.0f;
                isPaused = true;
                PauseMenu.SetActive(true);
                CamPlayer.enabled = false;
                CamMecha.enabled = false;
                WeaponController.enabled = false;
            }

        }
       

    }
    public void OnButtonPressOptionsJugar()
    {
        OptionsMenu.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }


    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenu.SetActive(false); 
        if(SwapCharacter.Instance.playerActive)
        {

            CamPlayer.enabled = true;
            CamMecha.enabled = false;
            WeaponController.enabled = true;
        }
        else
        {
            CamPlayer.enabled = false;
            CamMecha.enabled = true;
            WeaponController.enabled = false;
        }
        



    }


}
