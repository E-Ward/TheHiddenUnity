using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject CharacterCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//This is when the G keyboard button is pressed
        {
            CharacterCanvas.SetActive(true);
        }
    }
}
