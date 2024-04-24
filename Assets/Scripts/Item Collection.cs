using System.Collections;
using System.Collections.Generic;
using TMPro; // new
using Unity.VisualScripting; // new
using UnityEngine;
using UnityEngine.UI; // new

public class ItemCollection : MonoBehaviour
{
    int GoldenDumplings = 0;
    [SerializeField] TextMeshProUGUI DumplingText;

    int EnemiesKilled = 0;
    [SerializeField] TextMeshProUGUI EnemyText;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) // Gives access to the information of the other object 
    {
        //
        if(other.gameObject.CompareTag("GoldenDumplings"))
        {
            GoldenDumplings++;
            DumplingText.text = "Golden Dumplings: " + GoldenDumplings + " / 6";

            Destroy(other.gameObject); 
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StartIEnumerator(); // calls a function that starts a Coroutine in a GameManager script.
        }
    }

    void OnCollisionEnter (Collision other)
    {
        // enemies killed shown on UI.
        if(other.gameObject.CompareTag("EnemyHead"))
        {
            EnemiesKilled++;
            EnemyText.text = "Enemies Killed: " + EnemiesKilled;
        }
    }
}
