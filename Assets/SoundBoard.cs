using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class SoundBoard : ScriptableObject
{
    [SerializeField] int numbPlaylists = 0;
    [SerializeField] List<string> playlistNames = new List<string>();
    [SerializeField] public Playlist[] playlists = new Playlist[0];

    public List<string> getPlaylistNames () {
        playlistNames.Clear();
        foreach(Playlist p in playlists)
        {
            playlistNames.Add(p.title);
        }
        if(playlistNames == null)
        {
            playlistNames.Add("");
        }
        return playlistNames;
    }

    public Playlist[] getPlaylists () {
        return playlists;
    }

    public int addPlaylist () {
        Playlist[] temp = playlists;
        playlists = new Playlist[temp.Length + 1];
        for(int i = 0; i < temp.Length; i++)
        { playlists[i] = temp[i]; }
        playlists[playlists.Length - 1] = Playlist.CreateInstance<Playlist>();
        playlists[playlists.Length - 1].title = "Playlist " + (playlistNames.Count + 1);
        return playlists.Length - 1;
    }

    public void delete (int index) {
        if(index >= 0 && index <= playlists.Length - 1)
        {
            List<Playlist> temp = playlists.ToList<Playlist>();
            temp.RemoveAt(index);
            playlists = temp.ToArray<Playlist>();
        }
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