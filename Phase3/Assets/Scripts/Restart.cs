using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;


public class Restart : MonoBehaviour {

    void Update () {
        if (Input.GetKeyDown(KeyCode.C)){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //If want restart, uncomment this and change .C to .R
            //flowchart.ExecuteBlock("Start");
            SceneManager.LoadScene(20);
        }
	}
}
