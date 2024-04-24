using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject heroChar;
    private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        // this here finds the gameobject with the tag "player"
        GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // this changes the position from the current position and distance between the player and enemy
        Vector3 movePos = (heroChar.transform.position - transform.position).normalized; // 
        transform.Translate(movePos*speed*Time.deltaTime);
    }
}
