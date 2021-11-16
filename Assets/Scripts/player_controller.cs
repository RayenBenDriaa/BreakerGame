using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Grounded();
        Jump();
        Move();
        Boxe();
        run();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.anim.SetBool("jump",false);

            this.rb.AddForce(Vector3.up * 4f, ForceMode.Impulse);

        }

    }

    IEnumerator waitforAnimation()
    {
        yield return new WaitForSeconds(1.7f);
        this.anim.SetBool("boxe", true);
    }
    private void Boxe()
    {
        if (Input.GetMouseButtonDown(0) && this.grounded)
        {
            this.anim.SetBool("boxe",false);
            StartCoroutine(waitforAnimation());
           

        }

    }
    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;

        }
        else
        {
            this.grounded = false;

        }
        this.anim.SetBool("jump", this.grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.position += (movement * 0.4f) * Time.deltaTime;
        this.anim.SetFloat("vertical", verticalAxis == 0 ? Mathf.Abs(horizontalAxis) : verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);

    }
    private void run()
    {

        float verticalAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && verticalAxis != 0)
        {
         
          
            this.anim.SetTrigger("run");
        }
   

    }
}