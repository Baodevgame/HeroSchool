using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    float moveSpeed { get; set; }
    float jumpForce { get; set; }
    bool isGrounded { get; set; }
    Rigidbody2D rb { get; set; }
    void MovePlayer();
    void Jump();
}
