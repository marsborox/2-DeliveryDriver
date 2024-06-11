using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField]float steerSpeed = 300f;
    [SerializeField]float steerSlowSpeed = 150f;
    [SerializeField]float steerBoostSpeed = 450f;
    [SerializeField]float steerNormalSpeed = 300f;

    [SerializeField]float moveSpeed = 10f;
    [SerializeField]float slowSpeed = 5f;
    [SerializeField]float boostSpeed = 15f;
    [SerializeField]float normalSpeed = 10f;

    public bool speedUp = false;
    public bool speedDown = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Slow") { moveSpeed = slowSpeed; steerSpeed = steerSlowSpeed; }
        if (other.tag == "Boost") { moveSpeed = boostSpeed; steerSpeed = steerBoostSpeed; }
        if (other.tag == "Normal") { moveSpeed = normalSpeed; steerSpeed = steerNormalSpeed; }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        steerSpeed = steerSlowSpeed;
    }
}
