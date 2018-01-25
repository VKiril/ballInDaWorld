using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public DataContainer data;
    private AudioSource ballAudio;

    private void Start()
    {
        ballAudio = GetComponent<AudioSource>();
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            ballAudio.Play();
            data.ballHits++;

            var localRigidBody = gameObject.GetComponent<Rigidbody2D>();
            localRigidBody.AddForce(new Vector2(localRigidBody.velocity.x, 20f), ForceMode2D.Impulse);
        }
    }
}
