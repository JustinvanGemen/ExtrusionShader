using UnityEngine;
using System.Collections;

public class PlayerEat : MonoBehaviour {

	private GameObject _tempFood;
	private string _food;
	private Shader _shader;
	private float _fatness;

	private void Start()
	{
		_shader = GetComponent<Shader>();
		StartCoroutine("Weightloss");
	}

	private void OnTriggerStay (Collider other)
	{
		if (!other.CompareTag("Edible")) return;
		if (other.name == "Food")
		{		
			_fatness = _fatness + 0.01f;
			//_shader.material.SetFloat("Extrusion", _fatness);
		}
		other.name = "Eaten";
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
		_fatness = _fatness - 0.001f;
		//_shader.material.SetFloat("Extrustion", _fatness);
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("Weightloss");
	}
}
