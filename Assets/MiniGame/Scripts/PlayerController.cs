using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A controller for player movement of main player within the mini game
/// </summary>

public class PlayerController : MonoBehaviour
{

    /// <summary>
	/// The move speed of the main player and the animation of the walking
	/// </summary>
    public float MoveSpeed;
    private Animator _anim;

    /// <summary>
    /// Gets the animator component of main player
    /// </summary>
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    /// <summary>
    /// Checks the direction of the main player and sets the correct animation and translates the player accordingly
    /// </summary>
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime, 0f));
        }
        _anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        _anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }
}