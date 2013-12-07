using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AbilityBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	AimType AimType;
	CastType CastType;
	private double Manacost; //сколько маны нужно потратить на применение
	private double Cooldown; //время отката абилки, в секундах

}
