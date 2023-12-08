﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public int count = 0;
    public int prescore = 0;
    private double score;
    private int multiplier = 2;
    private int mcount = 1;
    private int mvalue;
    private double cvalue;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        mvalue = 10 + (multiplier * mcount);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over! You collected $" + score.ToString("n2") + " from " + count + " money signs.");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            count = count + 1;
            //easy mode
            if (count <= 10) {
                prescore = prescore + 1 * mvalue;
            }
            else if (count <= 22) {
                prescore = prescore + 5 * mvalue;
            }
            else if (count <= 35) {
                prescore = prescore + 10 * mvalue;
            }
            else if (count <= 45) {
                prescore = prescore + 25 * mvalue;
            }
            else if (count <= 56) {
                prescore = prescore + 50 * mvalue;
            }
            else if (count <= 66) {
                prescore = prescore + 100 * mvalue;
            }
            else if (count <= 76) {
                prescore = prescore + 200 * mvalue;
            }
            else if (count <= 86) {
                prescore = prescore + 500 * mvalue;
            }
            else if (count <= 87) {
                prescore = prescore + 1000 * mvalue;
            }
            else if (count <= 97) {
                prescore = prescore + 2000 * mvalue;
            }
            else if (count <= 107) {
                prescore = prescore + 5000 * mvalue;
            }
            else {
                prescore = prescore + 10000 * mvalue;
            }
            //hard mode
            /*if (score < 20) {
                score = score + 1;
            }
            else if (score < 60) {
                score = score + 2;
            }
            else if (score < 160) {
                score = score + 5;
            }
            else if (score < 360) {
                score = score + 10;
            }
            else if (score < 800) {
                score = score + 20;
            }
            else if (score < 1800) {
                score = score + 50;
            }
            else {
                score = score + 100;
            }*/
            score = (Mathf.Round(prescore * 100))/100000.00;
            cvalue = (Mathf.Round(mvalue * 10))/100.0;
            Debug.Log("$" + score.ToString("n2") + " -  Current Multiplier: x" + cvalue.ToString("f1"));
        }

    }

}
