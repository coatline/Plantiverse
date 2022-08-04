using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject cloudPrfab;
    public List<Cloud> clouds;
    public int dir = 1;

    public class Cloud
    {
        public float speed;
        public GameObject me;

        public void Move()
        {
            me.transform.Translate(new Vector2(speed, 0));
        }

        public void OnStart(GameObject cloudPrefab, Transform pos)
        {
            me = Instantiate(cloudPrefab, new Vector3(pos.position.x - .5f, pos.position.y + Random.Range(-.75f, .4f)), Quaternion.identity);
        }
    }

    float timer;
    float timetilnext;
    float cloudSpeed;

    void Start()
    {
        clouds = new List<Cloud>();
        timetilnext = Random.Range(1f, 4f);
        cloudSpeed = Random.Range(.01f, .03f) * dir;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timetilnext)
        {
            var cloud = new Cloud();
            cloud.OnStart(cloudPrfab, transform);
            clouds.Add(cloud);
            cloud.speed = cloudSpeed;

            cloudSpeed = Random.Range(.01f, .03f) * dir;
            timetilnext = Random.Range(2f, 8f);
            timer = 0;
        }

        for (int i = clouds.Count - 1; i >= 0; i--)
        {
            if (clouds[i].me.transform.position.x > 15 && dir == 1)
            {
                Destroy(clouds[i].me);
                clouds.Remove(clouds[i]);
            }
            else if(clouds[i].me.transform.position.x < -15 && dir == -1)
            {
                Destroy(clouds[i].me);
                clouds.Remove(clouds[i]);
            }
            else
            {
                clouds[i].Move();
            }
        }
    }
}
