using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBody : MonoBehaviour {

	public float Speed;
	public bool IsRotate;
	private GameObject MainBodyObj;
	
	void Awake () {
		
		MainBodyObj = this.gameObject;

	}
	
	void Update () {
		
		if (IsRotate) {

			MainBodyObj.transform.Rotate(0,0,Speed * Time.deltaTime);

		}

	}

}