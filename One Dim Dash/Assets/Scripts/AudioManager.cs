﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	public void play(string name) {
        PersistentAudioManager.instance.play(name);
    }
}
