using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    GameObject playerBody;
    Vector3 lookPos;

    Animator anim;

    public GameObject[] weapons;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerBody = this.gameObject.transform.GetChild(0).gameObject;
        anim = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //movement
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector3(horizontal, 0, vertical) * 1000);

        //animations
        if (vertical == 0 && horizontal == 0)
        {
            anim.SetTrigger("idle");
        }
        else
        {
            anim.SetTrigger("walk");
        }
    }

    private void Update()
    {
        //rotate player to point under cursor
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        playerBody.transform.LookAt(transform.position + lookDir, Vector3.up);

        //weapon controll
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var weapon in weapons)
            {
                weapon.GetComponent<IShooting>().Shot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (var weapon in weapons)
            {
                weapon.GetComponent<IShooting>().Reload();
            }
        }
    }
}
