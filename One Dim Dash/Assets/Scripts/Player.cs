﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private ParticleSystem thisParticleSystem;
    private SpriteRenderer thisSpriteRenderer;
    private BoxCollider2D thisCollider;

    private float deathAnimationDuration;

    public float extraWaitTime;

    void Start() {
        thisParticleSystem = gameObject.GetComponent<ParticleSystem>();
        thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        thisCollider = gameObject.GetComponent<BoxCollider2D>();
        deathAnimationDuration = thisParticleSystem.main.duration;
    }

    public void kill() {
        PersistentAudioManager.instance.play("DeathSound");
        thisParticleSystem.Play();
        thisSpriteRenderer.enabled = false;
        thisCollider.enabled = false;
        int finalScore = Mathf.RoundToInt(GameObject.Find("GameMaster").GetComponent<ScoreCounter>().currentScore);
        PlayerPrefs.SetInt("LastScore", finalScore);
        StartCoroutine(waitForDeathAnimationThenSwitchScene());
    }

    IEnumerator waitForDeathAnimationThenSwitchScene() {
        yield return new WaitForSecondsRealtime(deathAnimationDuration);
        SceneManager.LoadScene(2);
    }
}
