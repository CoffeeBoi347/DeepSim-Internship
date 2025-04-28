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

    [Header("Skill Values")]

    public float maxDis = 10f;
    public int coins;
    public int kills;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        InputControls();
        PlayerMovement();
        ShootPlayer();
    }

    private void InputControls()
    {
        moveInputVertical = Input.GetAxis("Vertical"); // for smoothened movement (W or S)
        moveInputHorizontal = Input.GetAxis("Horizontal"); // for smoothened movement (A or D)
        rb.velocity = new Vector3(moveInputHorizontal * velocity, 0f, moveInputVertical * velocity);

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
            rb.velocity = new Vector3(0f, velocity, 0f);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0f, -velocity, 0f);
        }
    }

    private void ShootPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDis))
            {
                if(hit.GetType() == typeof(AIEnemy))
                {
                    ActionManager actionManager = FindObjectOfType<ActionManager>();
                    actionManager.ApplyEffects();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }
}