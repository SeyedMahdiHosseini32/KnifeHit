using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

	[Header("Knifes")]
	public int KnifeCount;
	public float ShootSpeed = 2f;
	public Knife CurrentKnife;
	public Knife KnifePrefab;

	[Header("Positions")]
	public Transform StartKnifePos;
	public Transform EndKnifePos;

	private bool IsShoot;
	private float Temp;

	private MainBody MainBodyObj;

	void Start () {

		MainBodyObj = FindObjectOfType<MainBody>();
		
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (KnifeCount > 0) {
				IsShoot = true;
			}
		}

		if (IsShoot) {
			ShootKnife();
		}

	}

	public void ShootKnife () {
		
		Temp += ShootSpeed * Time.deltaTime;

		if (CurrentKnife != null) {
			CurrentKnife.gameObject.transform.position = new Vector3 
			(
				0,
				Mathf.Lerp(StartKnifePos.position.y,EndKnifePos.position.y,Temp),
				0
			);
		}
		if (Temp >= 1f) {
			IsShoot = false;
			Temp = 0f;
			KnifeCount--;
			CurrentKnife.gameObject.transform.SetParent(MainBodyObj.transform);
			if (KnifeCount > 0) {
				SpawnKnife();
			}
		}

	}

	public void SpawnKnife () {

		var SpawnObj = Instantiate(KnifePrefab.gameObject);
		CurrentKnife = SpawnObj.GetComponent<Knife>();

	}

}