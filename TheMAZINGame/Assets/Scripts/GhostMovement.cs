using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code found here: https://forum.unity.com/threads/making-an-object-move-and-then-stop-when-it-reaches-a-certain-point.440465/
public class GhostMovement : MonoBehaviour
{
    private bool correct = MathGhostInput.isCorrect;

    public float movementSpeed = 1;

    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(0, 20, 0);
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        correct = MathGhostInput.isCorrect;

        if (transform.position != endPosition && correct)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
        }
    }
}
