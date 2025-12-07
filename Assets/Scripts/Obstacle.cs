using UnityEngine;

public class Obstacle : MonoBehaviour
{
public float speed;
    void Update()
    {
     

      transform.Translate(Vector3.back*speed*Time.deltaTime);

      if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }

    }

    
}
