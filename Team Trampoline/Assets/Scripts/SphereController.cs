using UnityEngine;

public class SphereController : MonoBehaviour, IDrag //inherit from our interface, hover and CTRL + .
{
    private Rigidbody rb; //ref RigidBody on attached object

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void onStartDrag()
    {
        //throw new System.NotImplementedException();
        rb.useGravity = false; //ignore gravity when dragging
    }

    public void onEndDrag()
    {
        //throw new System.NotImplementedException();
        rb.useGravity = true; //reinstate gravity when done dragging
        rb.velocity = Vector3.zero; //object will drop straight down when dropped
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
