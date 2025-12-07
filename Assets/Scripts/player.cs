using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed;


    Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        float Horizontal=Input.GetAxis("Horizontal");
        rb.linearVelocity=new Vector3(Horizontal*speed,rb.linearVelocity.y,rb.linearVelocity.z);

        //transform.Translate(Horizontal *speed* Time.deltaTime,0,0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Block")
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }

 
}
