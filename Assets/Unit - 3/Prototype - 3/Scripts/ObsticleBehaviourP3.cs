using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleBehaviourP3 : MonoBehaviour
{
    public float speed;

    PlayerControllerP3 playerContollerP3;

    private void Start()
    {
        playerContollerP3 = GameObject.Find("Player").GetComponent<PlayerControllerP3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerContollerP3.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < -3f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
