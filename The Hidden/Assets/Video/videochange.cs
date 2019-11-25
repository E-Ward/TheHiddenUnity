using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class videochange : MonoBehaviour
{

    public AudioSource introsound;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AudioFinished", introsound.clip.length);
    }

    void AudioFinished()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
