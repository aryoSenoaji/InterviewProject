using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    AudioManager audioManager;
    public float strength = 5f;
    public float gravity = -9.81f;
    private Vector3 direction;

    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            audioManager.PlaySfx(audioManager.jump);
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            audioManager.PlaySfx(audioManager.gameOver);
        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncScore();
            audioManager.PlaySfx(audioManager.scoring);
        }
    }
}
