using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myCollider;
    AudioSource audioSource;
    SaveObject saveObject;
    Animator animator;

    [SerializeField] Slider chargeSlider;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] float chargeSpeed = 8f;
    [SerializeField] float jumpSpeed = 0f;
    [SerializeField] float maxJumpSpeed = 10f;
    [SerializeField] float secondJumpSpeed = 3f;

    int jumpCounter = 0;
    bool isOnGround = false;

    int doubleJumpLevel = 0;
    int chargeSpeedLevel = 0;
    int maxJumpSpeedLevel = 0;

    void Start()
    {
        saveObject = SaveSystem.GetSaveObject();
        TransferSaveObjectToGameObject(saveObject);

        chargeSpeed += ChargeSpeed.CHARGE_RATE_PER_LEVEL * chargeSpeedLevel;
        maxJumpSpeed += JumpSpeed.MAX_SPEED_RATE_PER_LEVEL * maxJumpSpeedLevel;

        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        audioSource.mute = PlayerPrefs.GetInt(AudioManager.MUTE_SOUND) == 1;
    }

    void Update()
    {
        if (jumpCounter < 2)
        {
            Jump();                
        }
    }

    private void Jump()
    {
        if (isOnGround)
        {
            if (Input.GetMouseButton(0))
            {
                ChargeEnergy();
            }

            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("isCharging", false);
                HandleJump(jumpSpeed, jumpSpeed);
                jumpSpeed = 0;
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0) && doubleJumpLevel > 0)
            {
                HandleJump(secondJumpSpeed, secondJumpSpeed);
            }
        }
    }

    private void HandleJump(float xSpeed, float ySpeed)
    {
        myRigidbody.velocity = new Vector2(xSpeed, ySpeed);
        PlayJumpSFX();
        jumpCounter++;
    }

    private void PlayJumpSFX()
    {
        audioSource.PlayOneShot(jumpSFX);
    }

    private void ChargeEnergy()
    {
        animator.SetBool("isCharging", true);
        jumpSpeed += Time.deltaTime * chargeSpeed;
        jumpSpeed = Mathf.Clamp(jumpSpeed, 0.7f, maxJumpSpeed);
        chargeSlider.value = jumpSpeed / maxJumpSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.x == 0)
        {
            isOnGround = true;
            jumpCounter = 0;
            animator.SetTrigger("isLanded");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    private void TransferSaveObjectToGameObject(SaveObject saveObject)
    {
        if (saveObject != null)
        {
            doubleJumpLevel = saveObject.doubleJump.upgradeLevel;
            chargeSpeedLevel = saveObject.chargeSpeed.upgradeLevel;
            maxJumpSpeedLevel = saveObject.jumpSpeed.upgradeLevel;
        }
    }
}
