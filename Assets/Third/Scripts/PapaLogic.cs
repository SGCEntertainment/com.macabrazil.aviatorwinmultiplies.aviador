using System.Collections;
using UnityEngine;

namespace Flipmorris
{
	public class PapaLogic : MonoBehaviour
	{
		int touchCount;

		private static PapaLogic _instance;

		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
			}
			else
			{
				Destroy(gameObject);
			}

			DontDestroyOnLoad(gameObject);
		}

		private void Start()
		{
			touchCount = 0;
		}

		private void Update()
		{
			if (touchCount >= 2 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex > 0)
			{
				Application.Quit();
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				touchCount++;

				StartCoroutine(Delay(0.3f));
			}
		}

		private IEnumerator Delay(float delta)
		{
			yield return new WaitForSeconds(delta);

			touchCount = 0;
		}
	}
}
