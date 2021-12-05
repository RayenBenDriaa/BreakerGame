using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Animator anim;
    public Animator Dooranim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded,tr;
    
   
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
    private void Update()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        
        Grounded();
        Jump();
        if (Input.GetButton("Sprint") && verticalAxis != 0)
        { 
            run();
        }
        else {
            Move(); 
        }
            
        Boxe();
        
    }
    // jumping when clicking space
    private void Jump()
    {
        bool s = this.anim.GetBool("run");
        if ((Input.GetButtonDown("Jump") && this.grounded && !s))
        {
            //loading jump animation
            this.anim.SetBool("jump", false);

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
            this.anim.SetBool("boxe", false);
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
    //movment function
    private void Move()
    {
        this.anim.SetBool("run", false);
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
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.Translate(Vector3.forward*3*Time.fixedDeltaTime);
        this.anim.SetBool("run",true);
        


    }
    //this function call the door animation to open
    public void openDoor()
    {
        bool b = this.Dooranim.GetBool("Dooropen");
      
            if (b)
            {
                this.Dooranim.SetBool("Dooropen", false);
                
            }
            else
            {

                this.Dooranim.SetBool("Dooropen", true);
            }

            

        

        
    }
    //this function callls the door to be closed
    void closeDoor()
    {

    }
}
