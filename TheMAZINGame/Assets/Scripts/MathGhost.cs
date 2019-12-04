using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathGhost : MonoBehaviour
{
    public bool dialogDisplayed = false;
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    void Awake()
    {
        // move and reduce the size of the cube
        //transform.position = new Vector3(0, 0.25f, 0.75f);
       // transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // add isTrigger
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;

        moveSpeed = 1.0f;

        // create a sphere for this cube to interact with
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.gameObject.transform.position = new Vector3(0, 0, 0);
        //sphere.gameObject.AddComponent<Rigidbody>();
        //sphere.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //sphere.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        //make him move according to you
        //transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter && !MathGhostInput.isCorrect)
        {
            SceneManager.LoadScene("MathGhostScene", LoadSceneMode.Additive);
            Debug.Log("entered - MathGhost");
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            if (stayCount > 0.25f)
            {
                //Debug.Log("staying - Math Ghost");
                stayCount = stayCount - 0.25f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit && !MathGhostInput.isCorrect)
        {
            SceneManager.UnloadSceneAsync("MathGhostScene");
            Debug.Log("exit - MathGhost");
        }
    }
}
