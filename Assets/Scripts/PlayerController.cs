using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float paddleSpeed;
    private bool rotation = false;
    private float totalRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float motion = Input.GetAxisRaw("Vertical");

        //Vector2.up; -> (0,1)
        //Vector2.down; -> (0,-1)
        //Vector2.right; -> (1,0)
        //Vector2.left; -> (-1,0)

        Vector3 posicionActual = transform.position;

        float nuevaPosY = Mathf.Clamp(posicionActual.y, -3, 3);

        transform.position = new Vector3(posicionActual.x, nuevaPosY, posicionActual.z);

        if (motion > 0) GetComponent<Rigidbody2D>().velocity = Vector2.up * paddleSpeed;
        if(motion < 0) GetComponent<Rigidbody2D>().velocity = Vector2.down * paddleSpeed;
        if (motion == 0) GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (!rotation && Input.GetKeyDown(KeyCode.Space))
        {

            rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
            rb.AddTorque(15, ForceMode2D.Impulse);
            rotation = true;
        }
        if (rotation)
        {
            totalRotation += Mathf.Abs(rb.angularVelocity) * Time.deltaTime;
        }

        if(totalRotation >= 360f)
        {

            rb.angularVelocity = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            transform.eulerAngles = Vector3.zero;

            rotation = false;
            totalRotation = 0f;
        }
    }
}
