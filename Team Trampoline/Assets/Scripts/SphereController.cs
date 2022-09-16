using UnityEngine;

public class SphereController : MonoBehaviour, IDrag //inherit from our interface, hover and CTRL + .
{
    //3D OBJECT VARIABLES
    [SerializeField]
    private Rigidbody rb; //ref RigidBody on attached object

    //private Renderer objectRenderer; //name variable for objectRenderer
    ////private SpriteRenderer spriteRenderer; //name variable for spriteRenderer
    //private Color objectColor; //name variable for objectColor

    private void Awake()
    {
        if(GetComponent<Rigidbody>())
        rb = GetComponent<Rigidbody>(); //get RigidBody if there is a RigidBody Component on the Object

        //objectRenderer = GetComponent<Renderer>(); //get Renderer Component (for 3D)
        //if (spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void onStartDrag()
    {
        //throw new System.NotImplementedException();
        if(rb) rb.useGravity = false; //ignore gravity when dragging

    }

    public void onEndDrag()
    {
        //throw new System.NotImplementedException();
        if (rb != null)
        {
            rb.useGravity = true; //reinstate gravity when done dragging
            rb.velocity = Vector3.zero; //object will drop straight down when dropped
                //WHY IS THIS NOT WORKING ANYMORE? 
        }

        //CHANGE COLOR
            //WHERE I LEFT OFF
            //CHECK IF OBJECT IS IN THE CORRECT PLACE, IF YES THEN OBJECT IS GREEN, IF NOT OBJECT IS RED


        //MOVING THIS TO THE TRIGGER SCRIPT
        //objectColor = new Color(255, 0, 0); //change color to red (1f,0,0 = 255,0,0)

        ////objectRenderer.material.SetColor("_Color", objectColor); //set new color to sphere (currently only working for 3D)
        //objectRenderer.material.color = objectColor; //set new color to sphere (currently only working for 3D
                                                     //ISSUE 2D sprite turns black...

        //if (spriteRenderer) spriteRenderer.color = objectColor; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
