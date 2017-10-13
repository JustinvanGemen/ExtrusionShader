using UnityEngine;
using System.Collections;

public class PlayerEat : MonoBehaviour {

	private GameObject _tempFood;
	private string _food;
	private Renderer _renderer;
	private float _ext;

	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		StartCoroutine("Weightloss");
	}

	private void OnTriggerStay (Collider other)
	{
		if(!other.CompareTag("Edible")) return;
		Debug.Log("Eating" + _ext);
		_ext = _ext +0.05f;
		_renderer.material.SetFloat("_Amount", _ext);
		_tempFood = other.gameObject;
		StartCoroutine ("Eat");
	}
	private IEnumerator Eat()
	{
		Destroy (_tempFood);
		yield return null;
	}

	private IEnumerator Weightloss()
	{
		Debug.Log("Weightloss" + _ext);
		_ext = _ext - 0.002f;
		_renderer.material.SetFloat("_Amount", _ext);
		yield return new WaitForSeconds(2f);
		StartCoroutine("Weightloss");
	}
}
