using System.Collections;
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
    private int multiplier0 = 2;
    private int multiplier1 = 1;
    private int mcount = 0;
    private int mvalue0;
    private int mvalue1;
    private double cvalue;
    [SerializeField]
    public int gamemode = 0;


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
        mvalue0 = 10 + (multiplier0 * mcount);
        mvalue1 = 2 + (multiplier1 * mcount);
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
            if (gamemode == 0)
            {
                if (count <= 10) {
                prescore = prescore + 1 * mvalue0;
                }
                else if (count <= 20) {
                    prescore = prescore + 5 * mvalue0;
                }
                else if (count <= 30) {
                    prescore = prescore + 10 * mvalue0;
                }
                else if (count <= 40) {
                    prescore = prescore + 25 * mvalue0;
                }
                else if (count <= 50) {
                    prescore = prescore + 50 * mvalue0;
                }
                else if (count <= 60) {
                    prescore = prescore + 100 * mvalue0;
                }
                else if (count <= 70) {
                    prescore = prescore + 200 * mvalue0;
                }
                else if (count <= 80) {
                    prescore = prescore + 500 * mvalue0;
                }
                else if (count <= 90) {
                    prescore = prescore + 1000 * mvalue0;
                }
                else if (count <= 100) {
                    prescore = prescore + 2000 * mvalue0;
                }
                else if (count <= 110) {
                    prescore = prescore + 5000 * mvalue0;
                }
                else {
                    prescore = prescore + 10000 * mvalue0;
                }
                score = (Mathf.Round(prescore * 100))/100000.00;
                cvalue = (Mathf.Round(mvalue0 * 10))/100.0;
                Debug.Log("$" + score.ToString("n2") + " -  Current Multiplier: x" + cvalue.ToString("f1"));
            }
            //hard mode
            if (gamemode == 1) {
                if (count <= 20) {
                prescore = prescore + 1 * mvalue1;
                }
                else if (count <= 40) {
                    prescore = prescore + 5 * mvalue1;
                }
                else if (count <= 60) {
                    prescore = prescore + 10 * mvalue1;
                }
                else if (count <= 80) {
                    prescore = prescore + 25 * mvalue1;
                }
                else if (count <= 100) {
                    prescore = prescore + 50 * mvalue1;
                }
                else if (count <= 120) {
                    prescore = prescore + 100 * mvalue1;
                }
                else if (count <= 140) {
                    prescore = prescore + 200 * mvalue1;
                }
                else if (count <= 160) {
                    prescore = prescore + 500 * mvalue1;
                }
                else if (count <= 180) {
                    prescore = prescore + 1000 * mvalue1;
                }
                else if (count <= 200) {
                    prescore = prescore + 2000 * mvalue1;
                }
                else if (count <= 220) {
                    prescore = prescore + 5000 * mvalue1;
                }
                else {
                    prescore = prescore + 10000 * mvalue1;
                }
                score = (Mathf.Round(prescore * 100))/100000.00;
                cvalue = (Mathf.Round(mvalue1 * 10))/100.0;
                Debug.Log("$" + score.ToString("n2") + " -  Current Multiplier: x" + cvalue.ToString("f1"));
            }
            
        }
        else if(other.gameObject.CompareTag("Multiplier")) {
            mcount = mcount + 1;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }

    }

}
