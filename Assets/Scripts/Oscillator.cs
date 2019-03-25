using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector3 = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    float movementFactor;
    Vector3 startingpos;
    void Start () {
        startingpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawsinwave = Mathf.Sin(cycles * tau);

        movementFactor = rawsinwave / 2f;
        Vector3 offset = movementVector3 * movementFactor;
        transform.position = startingpos + offset;
	}
}
