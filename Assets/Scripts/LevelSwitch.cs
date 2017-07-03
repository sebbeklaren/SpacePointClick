using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour {

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().doorClick)
        {
            SceneManager.LoadScene("OutDoorScene01");
            //ChangeLevel();
        }
	}

    //IEnumerator ChangeLevel()
    //{
    //    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().doorClick)
    //    {
    //        float fadeTime = GameObject.Find("LevelManager").GetComponent<Fading>().BeginFade(1);
    //        yield return new WaitForSeconds(fadeTime);
    //        //Application.LoadLevel(Application.);
    //    }
    //}
}
