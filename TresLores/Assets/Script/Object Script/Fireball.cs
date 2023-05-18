using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Wood")){
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("box")){
            Destroy(gameObject);
        }
    }
}
