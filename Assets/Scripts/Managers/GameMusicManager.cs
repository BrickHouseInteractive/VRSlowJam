﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicManager : MonoBehaviour {

	AudioSource audioSource;

	public AudioClip startMusic;
	public AudioClip knightMusic;
	public AudioClip dragonMusic;
	public AudioClip battleMusic;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		GameManager.onDragonWinEvent += PlayDragonMusic;
		GameManager.onKnightsWinEvent += PlayKnightsMusic;
		GameManager.onGameStartEvent += PlayBattleMusic;
		PlayMusic(startMusic);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayDragonMusic(){
        PlayMusic(dragonMusic);
	}

	void PlayKnightsMusic(){
        PlayMusic(knightMusic);
	}

	void PlayBattleMusic(){
        PlayMusic(battleMusic);
	}

	void PlayMusic(AudioClip audioClip){
		audioSource.clip = audioClip;
        FadeIn(audioSource);
    }

    void FadeOut(AudioSource audioSource)
    {
        StartCoroutine(AudioFadeOut.FadeOut(audioSource, 0.7f));
    }
    void FadeIn(AudioSource audioSource)
    {
        StartCoroutine(AudioFadeOut.FadeIn(audioSource, 3f));
    }
	void OnDestroy(){
		GameManager.onDragonWinEvent -= PlayDragonMusic;
		GameManager.onKnightsWinEvent -= PlayKnightsMusic;
		GameManager.onGameStartEvent -= PlayBattleMusic;
	}
}
