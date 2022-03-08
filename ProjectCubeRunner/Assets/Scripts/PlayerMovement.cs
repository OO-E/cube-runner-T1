using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public GameObject gameOverPanel;

    public float moveSpeed = 10f;
    public float jumpForce = 10f;

    bool isGrounded = true;
    void Start()
    {
       rb= GetComponent<Rigidbody>();
       gameOverPanel = GetComponent<GameManager>().losePanel;
        //GameManager.instance.BackToMenu();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            print("stay");
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            print("exit");
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FinishPoint")
        {
            gameOverPanel.SetActive(true);
            Invoke("BackToMenu", 2f);
            //backtomenu.BackToMenu();
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
                print("jumped");
            }
        }

        //clamp rotation on z 45

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), transform.position.y, transform.position.z);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
