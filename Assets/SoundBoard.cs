using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class SoundBoard : ScriptableObject
{
    [SerializeField] int numbPlaylists;
    [SerializeField] String[] playlistNames;
    [SerializeField] public Playlist[] playlists;

    public String[] getPlaylistNames () {
        return playlistNames;
    }

    public int getNumbPlaylists () {
        return numbPlaylists;
    }

    public Playlist[] getPlaylists () {
        return playlists;
    }
}

[Serializable]
public class Playlist : ScriptableObject {
    [SerializeField] public string title;
    [SerializeField] public AudioClip[] clips;

    public string getTitle () {
        return title;
    }

    public AudioClip[] getClips () {
        return clips;
    }
}