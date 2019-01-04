using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class LevelEditor : MonoBehaviour {
	public Transform mainBody;
	[Range(1,2)]
	public float Radius = 1;
	
	[Range(0,360)]
	public float move;
	public int AppleNumber;
	int _Number;

    public int Number
    {
        get
        {
            return this._Number;
        }
        set
        {
            this._Number = value;
			Create();
        }
    }
	public GameObject applePrefab;

	public List<GameObject> Apple;

	void Create () {
		if(Application.isEditor) {
			for (int i = 0; i < Apple.Count; i++) {
				DestroyImmediate(Apple[i]);
			}
			Apple.Clear();
			for (int i = 0; i < AppleNumber; i++) {
				var apple = Instantiate(applePrefab,mainBody.transform);
				Apple.Add(apple);
			}
		}
	}
	float temp2;
	void Update () {
		Number = AppleNumber;
		if(Application.isEditor) {

			for (int i = 1; i <= AppleNumber; i++) {
				var temp = 360 / AppleNumber;
				temp2 += temp;
				float Radian = (move+temp2)*Mathf.Deg2Rad;

				var pos = mainBody.position + new Vector3(Mathf.Cos(Radian)*Radius,Mathf.Sin(Radian)*Radius,0);

				Apple[i-1].transform.position = pos;
			}
		}
	}

}