using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    public GameObject gun;
    public GameObject bullet;
    Vector3 muzzle_position;
    Vector3 directionVec;
    public static Vector2 directionVec_n;
    Rigidbody2D rb;
    public float speed = 2.0f;
    public AudioClip sound_gun;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        directionVec_n = new Vector2(directionVec.x, directionVec.y);
        directionVec_n = directionVec_n.normalized;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseSystem.paused == false)
        {
            //Debug.Log(gun.transform.rotation);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 5"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        muzzle_position = this.transform.position;
        directionVec = new Vector3(1, 0, 0);
        directionVec_n = new Vector2(directionVec.x, directionVec.y);
        directionVec_n = directionVec_n.normalized;
        audioSource.PlayOneShot(sound_gun);
        GameObject newBullet = Instantiate(bullet, muzzle_position, gun.transform.rotation) as GameObject;
    }
}
