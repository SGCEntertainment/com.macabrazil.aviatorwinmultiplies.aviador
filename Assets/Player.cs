using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;

    private int coin;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void MoveUp()
    {
        if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 15)))
        {
            transform.Translate(5 * speed * Time.deltaTime, 0, 0);
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 15));
    }

    public void MoveDown()
    {
        if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, -20)))
        {
            transform.Translate(5 * speed * Time.deltaTime, 0, 0);
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -20));
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            SceneManager.LoadScene("Game");
        }

        if (collision.gameObject.tag == "Coin")
        {
            coin += 10;
            text.text = coin.ToString();
            text2.text = coin.ToString();
            Destroy(collision.gameObject);
        }
    }
}
