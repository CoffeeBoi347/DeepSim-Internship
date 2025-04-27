using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed Values")]

    public float velocity;
    private float moveInputVertical;
    private float moveInputHorizontal;
    public bool isMoving = false;

    [Header("Components")]

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        InputControls();
        PlayerMovement();
    }

    private void InputControls()
    {
        moveInputVertical = Input.GetAxis("Vertical"); // for smoothened movement (W or S)
        moveInputHorizontal = Input.GetAxis("Horizontal"); // for smoothened movement (A or D)
        rb.velocity = new Vector3(moveInputHorizontal * velocity * Time.deltaTime, 0f, moveInputVertical * velocity * Time.deltaTime);

        if(moveInputVertical > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0f, velocity * Time.deltaTime, 0f);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0f, -velocity * Time.deltaTime, 0f);
        }
    }
}