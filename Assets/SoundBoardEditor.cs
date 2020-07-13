using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundBoard))]
public class SoundBoardEditor : Editor
{
    SerializedProperty playlistNamesProp;

    private void OnEnable () {
        playlistNamesProp = serializedObject.FindProperty("playlistNames");
    }

    public override void OnInspectorGUI () {
        serializedObject.Update();
        var t = (target as SoundBoard);

        //Makes sure when a new SoundBoard is created in inspector the rest of the script doesnt throw a fit b/c playlist hasn't been initialized yet.
        if(t.playlists == null)
        {
            t.playlists = new Playlist[0];
        }

        //Checks to see if numbPlaylists has changed, if so, we need to re-initialize the playlist array
        if(t.playlists.Length != t.getNumbPlaylists())
        {
            //What to do if it went up
            if(t.playlists.Length < t.getNumbPlaylists())
            {
                var temp = new Playlist[t.playlists.Length];
                Debug.Log("Playlist.length does not equal numbPlaylists. Re-initializing");
                int count = 0;
                foreach(Playlist l in t.playlists)
                {
                    temp[count] = l;
                    count++;
                }
                t.playlists = new Playlist[temp.Length + 1];
                count = 0;
                foreach(Playlist l in temp)
                {
                    t.playlists[count] = l;
                    count++;
                }
                for(int x = 0; x < t.playlists.Length; x++)
                {
                    if(t.playlists[x] == null)
                    {
                        t.playlists[x] = Playlist.CreateInstance<Playlist>();
                    }
                }
            } 

            //What to do if it went down
            else if(t.playlists.Length > t.getNumbPlaylists())
            {
                var temp = new Playlist[t.getNumbPlaylists()];
                for(int x = 0; x < t.getNumbPlaylists(); x++)
                {
                    temp[x] = t.playlists[x];
                }
                t.playlists = new Playlist[t.getNumbPlaylists()];
                t.playlists = temp;
            }
        }

        //Variables for easier access
        Playlist[] lists = t.playlists;
        String[] names = t.getPlaylistNames();

        //PropertyFields for access to numbPLaylsit and playlistNames
        EditorGUILayout.PropertyField(serializedObject.FindProperty("numbPlaylists"));
        EditorGUILayout.PropertyField(playlistNamesProp);

        //For loop to handle displaying each Playlists
        for (int i = 0; i < t.playlists.Length; i++)
        {
            //Catch in case there's more playlists than names
            string n = null;
            if(i < names.Length)
            { n = names[i]; }

            //Catch in case any of the playlists are null
            if(lists[i] == null)
            {
                lists[i] = Playlist.CreateInstance<Playlist>();
            }

            //Catch in case there's more playlists than names.
            if (n != null)
            {
                lists[i].title = n;
            } else
            {
                Debug.LogError("More Playlists than names! Fix PlaylistNames Size please!");
                lists[i].title = "Set Name Please";
            }

            //Setup and create PropertyField for the Playlist. 
            var currentList = new SerializedObject(lists[i]);
            GUIContent l = new GUIContent();
            l.text = lists[i].title;
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(currentList.FindProperty("clips"), l);
            currentList.ApplyModifiedProperties();
        }
        serializedObject.ApplyModifiedProperties();

    }
}
