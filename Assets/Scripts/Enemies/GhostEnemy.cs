﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    SpriteRenderer sp;
    public int AppearSpeed;
    public float Frequency;

    new void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        
        float Alpha = (float) (Math.Sqrt((1 + Math.Pow(AppearSpeed,2)) / (1 + Math.Pow(AppearSpeed, 2) *
        Math.Pow(Math.Cos(timeCounter * Frequency),2))) * Math.Cos(timeCounter* Frequency));

        //Gets the color of the sprite
        Color AuxColor = sp.color;

        AuxColor.a = Alpha;
        sp.color = AuxColor;

    }
}