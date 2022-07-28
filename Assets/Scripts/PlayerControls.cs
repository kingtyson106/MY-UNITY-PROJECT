using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    #region variables
    public float moveSpeed = 5f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float xInput;
    private float zInput;
    private Rigidbody rb;
    private int count;
    public CharacterController playerController;
    private Vector3 moveDirection;
    public GameObject[] abilities;
    public bool stackAbilities = true;
    #endregion

    #region Text Variables
    private int pickUpCount;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        FindObjectOfType<GameManager>().setCountText(pickUpCount);
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText ();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        if(count <= 25)
        {
            winTextObject.SetActive(true);
        }
    }
    
    private void FixedUpdate()
        {
            moveDirection = new Vector3 (xInput, 0, zInput);
            playerController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }


       private void OnTriggerEnter(Collider other) //A function called whenever the player enters a trigger
    {

        if(other.gameObject.CompareTag("PickUp"))   //if the player hits a pickup...
        {
            pickUpCount += 1;   //Increment the score
            FindObjectOfType<GameManager>().setCountText(pickUpCount);    //Tell the Game Manager to update the score text
            other.gameObject.SetActive (false);    //Despawn the pickup game object
            count = count + 1;

            SetCountText();
        } 
        else if (other.gameObject.CompareTag("Enemy")) //if the player hits an enemy 
        {
            gameObject.SetActive(false);    //Despawn the player
            FindObjectOfType<GameManager>().EndGame();     //Tell the Game Manager to reset the level
        }
    }    
    
}
