using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem:MonoBehaviour {
    [Tooltip("If true, automatically calls DontDestroyOnLoad(this) on awake")]
    [SerializeField] bool dontDestroyOnLoad;

    [Tooltip("The soundboard to draw audio from")]
    [SerializeField] SoundBoard soundBoard;

    [Tooltip("Calls Debug.Log every time playSound is called, so you can figure out if you've got your SoundBoard setup correctly")]
    [SerializeField] bool debugMode = false;

    AudioSource myAudio;

    private void Awake () {
        if(dontDestroyOnLoad)
        { DontDestroyOnLoad(this); }
    }

    // Start is called before the first frame update
    void Start () {
        myAudio = this.GetComponent<AudioSource>();
        if(false)
        {
            Debug.Log("sTOP");
        }
    }

    public void playSound () {
        Debug.LogError("Attempted to call SoundSystem.playSound without input, aborting!");
    }

    public void playSound (int playlistIndex, int clipIndex) {
        if(debugMode) {
            Debug.Log("Calling playSound on playlist: " + playlistIndex + " " + soundBoard.playlists[playlistIndex].title);
            Debug.Log("Clip Name: " + soundBoard.playlists[playlistIndex].clips[clipIndex].name);
        }

        myAudio.clip = soundBoard.playlists[playlistIndex].clips[clipIndex];
        myAudio.Play();
    }

}
