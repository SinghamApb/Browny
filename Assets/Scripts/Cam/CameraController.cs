using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _player;
    public Transform farbackground, middleBackground;
    private float _lastPosX;
   [SerializeField] private float minHeight, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerController = FindAnyObjectByType<PlayerController>();
        if (playerController != null)
        {
            _player = playerController.transform;
            _lastPosX = transform.position.x;
        }
        else
        {
            Debug.LogWarning("PlayerController not found.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Player track 
        transform.position = new Vector3(_player.position.x, Mathf.Clamp(_player.position.y, minHeight, maxHeight), transform.position.z);
        BackgroundTrack();
     
    }


    void BackgroundTrack()
    {
        float moveAmount = transform.position.x - _lastPosX;

        farbackground.position += new Vector3(moveAmount, 0f, 0f);
        middleBackground.position += new Vector3(moveAmount * 0.5f, 0f, 0f);
        _lastPosX = transform.position.x;

    }
}
