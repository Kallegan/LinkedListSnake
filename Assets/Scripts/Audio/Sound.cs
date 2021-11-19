using UnityEngine;

namespace Audio
{
    [System.Serializable] //manages the sound files and settings.
    public class Sound
    {
        public string name;
    
        public AudioClip clip;
    
        [Range(0,1f)]
        public float volume;
        [Range(0,3f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}
