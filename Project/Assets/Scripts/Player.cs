using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 2;
    [SerializeField] TMP_Text popupText = null;
    [SerializeField] AudioClip jetpack;
    [SerializeField] AudioClip plantSound;

    Rigidbody2D rb;
    AudioSource[] audioSources;
    ParticleSystem ps;
    Inventory inventory;

    public int currentPlants;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInChildren<ParticleSystem>();

        ps.Play();
    }

    float zRotation;

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(0, transform.position.y, -10);
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Jump");

        rb.angularVelocity = 0;

        if (x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, zRotation);
            zRotation -= rotateSpeed;
        }
        else if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, zRotation);
            zRotation += rotateSpeed;
        }

        if (y > 0)
        {
            Vector2 direction = transform.rotation * Vector3.up;

            Vector2 force = new Vector2(3, 3);

            rb.AddForce(force * direction);

            ps.startColor = new Color(ps.startColor.r, ps.startColor.g, ps.startColor.b, 255);

            if (!audioSources[0].isPlaying)
            {
                audioSources[0].PlayOneShot(jetpack);
            }

        }
        else
        {
            ps.startColor = new Color(ps.startColor.r, ps.startColor.g, ps.startColor.b, 0);

            audioSources[0].Stop();

        }

        if (rb.angularVelocity > 0)
        {
            rb.angularVelocity = 0;
        }

        if (popup)
        {
            alpha -= Time.deltaTime / 1.5f;
            ay += Time.deltaTime * 50;
            popupText.color = new Color(1, 1, 1, alpha);
            popupText.rectTransform.anchoredPosition = new Vector3(0, ay, 0);

            if (alpha <= 0)
            {
                popup = false;
                alpha = 1;
                popupText.color = new Color(1, 1, 1, 1);
                popupText.gameObject.SetActive(false);
                ay = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !inventory.gameObject.active)
        {
            inventory.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.gameObject.SetActive(false);
        }

    }

    float ay;
    float alpha = 1;
    float speed = 4;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                var planetScript = collision.gameObject.GetComponentInParent<Planet>();


                if (planetScript.plantNum > 0)
                {
                    inventory.AddPlant(planetScript.plants);
                    currentPlants += planetScript.plantNum;
                    audioSources[1].volume = 1;
                    audioSources[1].PlayOneShot(plantSound);
                    planetScript.plantNum = 0;
                    Earth.I.plantNum = currentPlants;
                }
                else
                {
                    popupText.enabled = true;
                    popupText.gameObject.SetActive(true);
                    popup = true;
                }
            }
        }
    }

    bool popup;

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Planet"))
    //    {
    //        rb.velocity = new Vector2(0, 0);

    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            var planetScript = collision.gameObject.GetComponent<Planet>();


    //            if (planetScript.plantNum > 0)
    //            {
    //                inventory.AddPlant(planetScript.plants);
    //                currentPlants += planetScript.plantNum;
    //                planetScript.plantNum = 0;
    //                Game.I.plantNum = currentPlants;
    //            }
    //            else
    //            {
    //                popupText.rectTransform.anchoredPosition = Vector3.zero;
    //                popupText.enabled = true;
    //                popupText.gameObject.SetActive(true);
    //                popup = true;
    //            }


    //        }
    //    }
    //}

}
