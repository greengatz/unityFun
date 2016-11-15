using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    float dt;

    public GameObject target;

    public float rotationSpeed;
    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frames
	void Update () {
        dt = Time.deltaTime;

        turn();
        move();
	}

    void turn()
    {
        Quaternion quatDir = this.gameObject.transform.rotation;

        Vector3 currentDir = this.gameObject.transform.forward;
        Vector3 goalDir = this.gameObject.transform.position - target.transform.position;
        float angleDiff = Vector3.Dot(currentDir, goalDir) * 90;
        angleDiff = Mathf.Clamp(angleDiff, -1 * rotationSpeed, rotationSpeed); // rescaling and sanitizing

        Quaternion angleChange = Quaternion.AngleAxis(angleDiff * dt, new Vector3(0, 1, 0));
        this.gameObject.transform.rotation = quatDir * angleChange;
    }

    void move()
    {
        this.gameObject.transform.Translate(new Vector3(speed * dt, 0));
    }
}
