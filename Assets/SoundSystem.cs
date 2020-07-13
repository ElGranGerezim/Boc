using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] bool dontDestroyOnLoad;
    [SerializeField] SoundBoard soundBoard;
    AudioSource myAudio;

    private void Awake () {
        if(dontDestroyOnLoad)
        { DontDestroyOnLoad(this); }
    }

    // Start is called before the first frame update
    void Start () {
        myAudio = this.GetComponent<AudioSource>();
    }

    public void playSound () {
        Debug.LogError("Attempted to call SoundSystem.playSound without input, aborting!");
    }

    public void playSound (int index) {

    }
}
