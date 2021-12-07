using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip JumpSound;
    public AudioClip CrushSound;
    private AudioSource PlayerAudio;
    public ParticleSystem Dirt;
    public ParticleSystem explosion;
    private Animator PlayerAnim;
    public bool gameOver = false;
    public bool onGround = true;
    public float gravityModifier = 1;
    public float jumpForce = 1000;
    private Rigidbody PlayerRB;
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerAudio = GetComponent<AudioSource>();
        PlayerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            PlayerAnim.SetTrigger("Jump_trig");
            Dirt.Stop();
            PlayerAudio.PlayOneShot(JumpSound, 1);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            Dirt.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            explosion.Play();
            Dirt.Stop();
            PlayerAudio.PlayOneShot(CrushSound, 1);
        }
    }
}
