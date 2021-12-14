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
    public GameObject Explosion;

    /*
    void Awake()
    {
#if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
#endif
    }*/
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Grounded();
        Jump();
        Move();
        Boxe();
        Spell();
        run();
    }
    // jumping when clicking space
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && this.grounded)
        {//loading jump animation
            this.anim.SetBool("jump",false);

            this.rb.AddForce(Vector3.up * 4f, ForceMode.Impulse);

        }

    }

    IEnumerator waitforAnimation()
    {
        yield return new WaitForSeconds(1.7f);
        this.anim.SetBool("boxe", true);
    }
    //Attack function
    private void Boxe()
    {
        if (Input.GetButtonDown("Fire1") && this.grounded)
        {
            this.anim.SetBool("boxe",false);
            StartCoroutine(waitforAnimation());
           

        }

    }
    IEnumerator waitforAnimation2()
    {
        yield return new WaitForSeconds(1.7f);
        this.anim.SetBool("spell", true);
        Explosion.SetActive(false);

    }
    //spell function
    private void Spell()
    {
        if (Input.GetButtonDown("spell") && this.grounded)
        {
            Debug.Log("hola");
            this.anim.SetBool("spell", false);
            Explosion.SetActive(true);
            StartCoroutine(waitforAnimation2());


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
    //movment function
    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.position += (movement * 0.7f) * Time.deltaTime;
        this.anim.SetFloat("vertical", verticalAxis == 0 ? Mathf.Abs(horizontalAxis) : verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);

    }
    //when i press left shift he run
    private void run()
    {

        float verticalAxis = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Sprint") && verticalAxis != 0)
        {
         
          
            this.anim.SetTrigger("run");
        }
   

    }
}