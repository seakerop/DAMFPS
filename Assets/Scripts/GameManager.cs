using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField]  private GameObject MenuEnJuego;
    [SerializeField]  private GameObject playerController;
    [SerializeField]  private GameObject playerShooting;
    [SerializeField]  private GameObject mouseController;




    private PlayerMovement playerMovement;
    private Shooting playerShootingAction;
    private MouseController mouseControllerAction;
   

    private float score = 0;

  
    public void ReenableControls ()
    {
        MenuEnJuego.SetActive(false);
        Time.timeScale = 1;
        playerMovement.enabled = true;
        playerShootingAction.enabled = true;
        mouseControllerAction.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Awake()
    {
        playerMovement = playerController.GetComponent<PlayerMovement>();
        playerShootingAction = playerShooting.GetComponent<Shooting>();
        mouseControllerAction = mouseController.GetComponent<MouseController>();




    }

    // Update is called once per frame
    void Update()
    {

        score += Time.deltaTime;

       
        scoreText.text = "Score: " + score.ToString("0.0");

       

        if (Input.GetKeyDown("escape") && MenuEnJuego.activeInHierarchy == false) 
        {
            
            MenuEnJuego.SetActive(true);
            Time.timeScale = 0;
            playerMovement.enabled = false;
            playerShootingAction.enabled = false;
            mouseControllerAction.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;




        }
        else if (Input.GetKeyDown("escape") && MenuEnJuego.activeInHierarchy == true)
        {
            ReenableControls();
        }

    }

}
