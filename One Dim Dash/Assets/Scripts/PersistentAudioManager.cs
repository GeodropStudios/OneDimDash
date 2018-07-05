﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Inspired by Brackeys: https://www.youtube.com/watch?v=6OT43pvUyfY
public class PersistentAudioManager : MonoBehaviour {
    
    public Sound[] sounds;
    
    public static PersistentAudioManager instance { get; private set; }
    
	void Awake() {
        
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start() {
        play("StartMenuTheme");
    }

    public void play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
        Debug.Log("Playing " + name);
    }
}
