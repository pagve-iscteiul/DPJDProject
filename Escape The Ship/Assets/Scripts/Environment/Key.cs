using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Key : MonoBehaviour
{
    //[SerializeField] private Animator associatedDoor = null;

    public string password = "1234";
    public GameObject associatedDoor = null;
    //public GameObject enemy = null;
    //public GameObject guardSpawnPoint;
    //public GameObject guardRoute; // assuming the starting point beeing the transform of the object given and route beeing the children of the object
    //public float timeTillSpawn = 60f;

    //void Start()
    //{
    //    Debug.Log("pressed");
    //    StartCoroutine(waiter());
    //}

    void OnMouseDown()
    {
        Transform parent = transform.parent;
        GameObject canvas = parent.Find("Canvas").gameObject;
        TextMeshProUGUI input = canvas.GetComponentInChildren<TextMeshProUGUI>();

        string key = gameObject.name;

        if (key == "DELETE")
        {
            if (input.text != null && input.text != string.Empty)
            {
                input.text = input.text.Remove(input.text.Length - 1);
            }
        }
        else if (key == "ENTER")
        {
            if (associatedDoor != null)
            {
                if (input.text == password && associatedDoor != null)
                {

                    input.color = new Color32(0, 153, 51, 255); // Green
                    //associatedDoor.Play("OpenDoor", 0, 0.0f);
                    associatedDoor.GetComponent<DoorScript>().Activate();

                    //if(enemy != null)
                    //{
                    //    StartCoroutine(waiter());
                    //}
                }
                else
                {
                    input.color = new Color32(204, 0, 0, 255); // Red
                }
            }
            else
            {
                input.color = new Color32(204, 0, 0, 255); // Red
            }
            
        }
        else
        {
            if (input.text == null || input.text == string.Empty)
            {
                input.text = key;
            }
            else
            {
                if(input.text.Length < 4)
                {
                    input.text = input.text + key;
                }
            }
        }

    }

    //IEnumerator waiter()
    //{
    //    yield return new WaitForSeconds(timeTillSpawn);
    //    GameObject g = Instantiate(enemy, guardRoute.transform.position, guardRoute.transform.rotation);
    //    g.GetComponent<Guard>().route = guardRoute;
    //    //enemy.GetComponent<Guard>().route = guardRoute;

    //    //enemy.getPatrolRoute();
    //}
}
