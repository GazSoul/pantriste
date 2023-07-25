using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{    
    public float EnemySpeed;
    public Transform TurnPoint;
    private bool movingRight = true;
    public float distance;

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(Vector2.right * EnemySpeed * Time.deltaTime);

        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D boxes = Physics2D.Raycast(TurnPoint.position, Vector2.down, distance, mask);
            if (boxes.collider == false){
                print("Collision");
                if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0,-180,0);
                    movingRight = false;
                } else
                {
                    transform.eulerAngles = new Vector3(0,0,0);
                    movingRight = true;
                }
            }
        
    }
}
