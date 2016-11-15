using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Action source;
    public Combatant target;

    public float rotationSpeed = 100f;
    public float rotationAccel = 0f;
    public float speed = 100f;
    public float speedAccel = 0f;
    public float accelRate = 0.0f;

	// Use this for initialization
	void Start () {
	}

    public void initialize(Action source, Combatant target, float speed, float rotationSpeed)
    {
        this.source = source;
        this.target = target;
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
    }

    public void setAccels(float velocity, float rotation, float ratePerSecond)
    {
        rotationAccel = rotation;
        speedAccel = velocity;
        accelRate = ratePerSecond;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        accelerate(dt);
        turn(dt);
        move(dt);
    }

    void accelerate(float dt)
    {
        speed += accelRate * speedAccel * dt;
        rotationSpeed += accelRate * rotationAccel * dt;
    }

    void turn(float dt)
    {
        Quaternion originalRot = this.gameObject.transform.rotation;
        transform.LookAt(((MonoBehaviour)target).gameObject.transform);
        Quaternion desiredRot = this.gameObject.transform.rotation;

        this.gameObject.transform.rotation = Quaternion.RotateTowards(originalRot, desiredRot, rotationSpeed * dt);
    }

    void move(float dt)
    {
        this.gameObject.transform.Translate(Vector3.forward * dt * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        source.report(this);
    }
}
