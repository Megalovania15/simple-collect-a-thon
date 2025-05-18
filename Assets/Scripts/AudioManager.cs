using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //the audio manager can be used to keep track of all of the clips on the character and how we
    //select them
    public AudioClip[] audioClips;

    //we can use a switch statement and method to select a clip to play
    public AudioClip SelectClip(string clipName)
    {
        switch (clipName)
        {
            case "Eat":
                return audioClips[0];
            case "Die":
                return audioClips[1];
            default:
                Debug.Log("Audio clip not selected");
                return null;
        }
    }
}
