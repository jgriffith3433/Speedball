using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public enum PP
    {
        Left,
        Middle,
        Right
    }
    public GameObject rightPosition, leftPosition, deadPrefab, middlePosition;
    
    bool changePosition, startGame;
    PP currentPlayerPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            startGame = true;
            currentPlayerPosition = PP.Left;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            startGame = true;
            currentPlayerPosition = PP.Middle;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            startGame = true;
            currentPlayerPosition = PP.Right;
        }

        if (startGame == false)
        {
            return;
        }

        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);

        if (currentPlayerPosition == PP.Left)
        {
            transform.position = new Vector3(leftPosition.transform.position.x, transform.position.y, transform.position.z);
        }
        if (currentPlayerPosition == PP.Middle)
        {
            transform.position = new Vector3(middlePosition.transform.position.x, transform.position.y, transform.position.z);
        }
        if (currentPlayerPosition == PP.Right)
        {
            transform.position = new Vector3(rightPosition.transform.position.x, transform.position.y, transform.position.z);
        }


    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "wall"){
            transform.gameObject.SetActive(false);
            for(int i = 0; i < 17; i++){
                Instantiate(deadPrefab, transform.position, Quaternion.identity);
            }
        }

        if(other.tag == "finish"){
            Debug.Log("Finish");
        }
    }
}
