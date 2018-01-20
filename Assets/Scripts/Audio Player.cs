//This script allows you to toggle music to play and stop.
//Assign an AudioSource to a GameObject and attach an Audio Clip in the Audio Source. Attach this script to the GameObject.

using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource _mMyAudioSource;

    //Play the music
    bool _mPlay;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool _mToggleChange;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        _mMyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        _mPlay = true;
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (_mPlay == true && _mToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            _mMyAudioSource.Play();
            //Ensure audio doesn’t play more than once
            _mToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (_mPlay == false && _mToggleChange == true)
        {
            //Stop the audio
            _mMyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
            _mToggleChange = false;
        }
    }

    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        _mPlay = GUI.Toggle(new Rect(10, 10, 100, 30), _mPlay, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            _mToggleChange = true;
        }
    }
}