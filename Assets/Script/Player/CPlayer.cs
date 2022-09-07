using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    // Public
    public float moveSpeed = 10.0f;
    public float interactRange = 2.0f;
    public int damage = 1;

    // Private
    private List<CItem> playerInventory;
    private GameManager gameManager;



    /*  Start is called before the first frame update
    *   @version 1.0
    */
    void Start()
    {
        playerInventory = new List<CItem>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }



    /*  Update is called once per frame
    *   @version 1.0
    */
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        // transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        transform.position += movementDirection * moveSpeed * Time.deltaTime;

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 1);

            // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.switchUIInventory();
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * interactRange;
        Debug.DrawRay(transform.position, forward, Color.green);
    }



    /*  Interact with the GameObject in front of the Player
    *   @since version 0.1
    *   @version 1.0
    */
    void Interact()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit, interactRange))
        {
            if (hit.transform.tag == "Resource")
            {
                hit.transform.gameObject.GetComponent<CResource>().interact(damage);
            }
        }
    }



    /*  Add an item to the Player inventory
    *   @since version 0.1
    *   @version 1.0
    */
    public void addItemToInventory(CItem item)
    {
        playerInventory.Add(item);
    }
}
