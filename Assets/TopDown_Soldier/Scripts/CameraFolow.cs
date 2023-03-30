using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] 
    private float speed = 10;
    private void LateUpdate() {
        var playerPosition = GameManager.Instance.player.transform.position;
        playerPosition.z = transform.position.z;
        transform.position = Vector3.Slerp(transform.position, playerPosition,speed);
    }
}
