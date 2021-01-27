using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparador : MonoBehaviour {

    public Transform mira;
    float power;
    float minPower = 0f;
    public float maxPower = 100f, limit;
    public Slider poderSlider;
    List<Rigidbody> ballList;
    bool ballReady;
    public float escala = 1;
    bool topped;


    void Start () {
        poderSlider.minValue = 0f;
        poderSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();

	}

    void Update() {

        

        if (ballReady)
        {
            poderSlider.gameObject.SetActive(true);
        }
        else
        {
            poderSlider.gameObject.SetActive(false);
        }
        poderSlider.value = power;
        poderSlider.maxValue = maxPower;
        if (ballList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (topped)
                    power -= 100  * Time.deltaTime * escala;
                else
                    power += 100  * Time.deltaTime * escala;

                if (power > maxPower)
                    topped = true;
                else if (power < 0)
                    topped = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (power < limit)
                    power = limit;
                foreach(Rigidbody r in ballList)
                    r.AddForce(power * mira.forward);
            }
        }
        else
        {
            ballReady = false;
            power = 0f;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
