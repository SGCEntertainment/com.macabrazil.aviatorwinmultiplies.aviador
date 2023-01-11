using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanwer : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject[] pos;

    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));

        Instantiate(platforms[Random.Range(0, platforms.Length)], pos[Random.Range(0, pos.Length)].transform.position, Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
