using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
	public void Lvl1()
	{
		SceneManager.LoadScene("lvl 1");
	}
	public void Lvl2()
	{
		SceneManager.LoadScene("lvl 2");
	}
	public void Lvl3()
	{
		SceneManager.LoadScene("congrats");
	}
	public void Lvl4()
	{
		SceneManager.LoadScene("menu");
	}
		public void BackToMenu()
	{
		SceneManager.LoadScene("menu");
	}
}