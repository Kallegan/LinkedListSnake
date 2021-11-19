using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour

    {
        public Sound[] sounds;

        public static AudioManager instance;

        private void Awake() //checks if an audiomanager is in scene, and destroys to avoid multiple.
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        
            DontDestroyOnLoad(gameObject); 
        
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                s.source.loop = s.loop;
            }
        }

        void Start() //starts the music when starting game.
        {
            Play("Music");
        }
    
        public void Play(string name) //finds the sound in array to play.
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s?.source.Play(); 
        }
    }
}
