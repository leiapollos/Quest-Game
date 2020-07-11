﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    protected Canvas current;

    protected GameObject pauseScreen;

    void Start(){
        if(SceneManager.GetActiveScene().name.Equals("Menu"))
            current = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        
        if(SceneManager.GetActiveScene().name.Equals("Main")){
            PlayerPrefs.SetInt("isPaused", 0);
            pauseScreen = GameObject.Find("PauseScreen");
            pauseScreen.SetActive(false);
        }
    }

    public float ScaleSize = 1.1f;
    public float ScaleSpeed = 0.3f;

    public void Scale(GameObject obj){
        LeanTween.scale(obj, new Vector3(ScaleSize, ScaleSize, ScaleSize), ScaleSpeed).setIgnoreTimeScale(true);
    }

    public void StopScale(GameObject obj){
        LeanTween.scale(obj, new Vector3(1.0f, 1.0f, 1.0f), ScaleSpeed).setIgnoreTimeScale(true);
    }

    public void LoadGame(){
        SceneManager.LoadScene("Main");
    }

    public void LoadCanvas(Canvas canvas){
        current.gameObject.SetActive(false);
        current = canvas;
        current.gameObject.SetActive(true);
        ResetScale();
    }

    public void ResetScale(){
        GameObject[] btns = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject bt in btns){
            bt.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void Exit(){
        Application.Quit();
    }

    void Update(){
        if(SceneManager.GetActiveScene().name.Equals("Main")){
            HandlePause();
        }
    }

    
    public void HandlePause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            int isPaused = PlayerPrefs.GetInt("isPaused");
            if(isPaused == 1){
                PlayerPrefs.SetInt("isPaused", 0);
                pauseScreen.SetActive(false);
                Time.timeScale = 1;

            }else{
                PlayerPrefs.SetInt("isPaused", 1);
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
