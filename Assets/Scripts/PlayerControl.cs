using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;
    public Text timerText;
    public float timer;
    public bool timerOn;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 0;
        SetCountText();
        winText.text = "";
        timerOn = true;

    }

    private void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
        }

        string minutes = ((int)timer / 60).ToString();
        string seconds = (timer % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertictal = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertictal);    //

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            timerOn = false;
            winText.text = "Game Over";
        }
    }
}
