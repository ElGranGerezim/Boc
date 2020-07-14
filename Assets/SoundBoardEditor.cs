using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundBoard))]
public class SoundBoardEditor : Editor
{
    public int index = 0;

    public override void OnInspectorGUI () {
        serializedObject.Update();
        var t = (target as SoundBoard);


        //Variables for easier access
        List<string> names = t.getPlaylistNames();

        //Style and Label
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontStyle = FontStyle.Bold;
        GUILayout.Label("Select a playlist", myStyle);

        //The all powerful controller for this whole script, index. DO NOT TOUCH
        index = EditorGUILayout.Popup(index, listToArray(names));

        //Utility Buttons
        if(GUILayout.Button("Create Playlist"))
        {
            index = t.addPlaylist();
        }
        if(GUILayout.Button("Delete Current Playlist"))
        {
            t.delete(index);
            index = 0;
        }

        //Style Spaces
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //Makes sure we aren't trying to draw a playlist that doesn't exist
        if(index <= t.playlists.Count() - 1)
        {
            EditorGUILayout.LabelField("Playlist Name: ", myStyle);
            t.playlists[index].title = EditorGUILayout.TextField(t.playlists[index].title);
            var currentList = new SerializedObject(t.playlists[index]);
            EditorGUILayout.PropertyField(currentList.FindProperty("clips"));
            currentList.ApplyModifiedProperties();
        }

        serializedObject.ApplyModifiedProperties();
    }

    private string[] listToArray (List<string> names) {
        string[] r = new string[names.Count];
        for(int i = 0; i < names.Count; i++)
        {
            r[i] = names[i];
        }
        return r;
    }

}
