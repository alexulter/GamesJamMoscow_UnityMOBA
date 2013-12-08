using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AbilityBase : MonoBehaviour {

	AimType AimType;
	CastType CastType;
	private double Manacost; //сколько маны нужно потратить на применение
	private double Cooldown; //время отката абилки, в секундах
	public string Name; //название абилки

	public void OnCast ()
	{
	}

}
