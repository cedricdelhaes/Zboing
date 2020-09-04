using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInputs : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    [SerializeField]
    private Vector3 mousePosition;

    public GameObject gameOverPlane;

    [Header("Jump settings"), SerializeField]
    float jumpPower = 3f;
    [SerializeField]
    float jumpDuration = 0.2f;
    [SerializeField]
    float forwardSpeed = 5f;

    bool jumpStarted = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the camera following player
        mainCamera.transform.localPosition = new Vector3(0, 0, player.transform.position.z) + new Vector3(-1,4,-15);

        //Get mouse position on screen to apply X translation to the player
        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y = 0;

        if(jumpStarted)
            player.transform.DOMoveX(player.transform.position.x + mousePosition.x / 100, 0.1f);

        //Space trigger ta begin the jump loop
        if (!jumpStarted && Input.GetMouseButtonDown(0))
            startJump();
    }

    //Jump loop
    void startJump()
    {
        jumpStarted = true;
        player.transform.DOJump(endValue: new Vector3(0, 0, player.transform.position.z) + Vector3.forward * forwardSpeed, 
            jumpPower: jumpPower, numJumps: 1, duration:jumpDuration).SetDelay(0.5f).OnComplete(startJump);
    }
}
