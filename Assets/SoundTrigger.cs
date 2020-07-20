using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SoundTrigger : MonoBehaviour
{
    [Tooltip("The index of the playlist to play from (Counting from Zero)")]
    [SerializeField] int playlistIndex;

    [Tooltip("The index of the sound to play (Counting from Zero)")]
    [SerializeField] int soundIndex;

    private void OnTriggerEnter (Collider other) {
        if(other.gameObject.GetComponent<SoundSystem>())
        {
            other.gameObject.GetComponent<SoundSystem>().playSound(playlistIndex, soundIndex);
        }
    }
}
