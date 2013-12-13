using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroBase : MonoBehaviour {

	public double MaxHealthPoints{get;set;}
	public double HealthPoints = 100f;//{get;set;}
	public double HealthRegen{get;set;}
	public double MaxManaPoints{get;set;}
	public double ManaPoints{get;set;}
	public double ManaRegen{get;set;}
	public double MoveSpeed = 10f;//{ get; set; }
	public double AttackPower{get;set;}
	public double MagicPower{get;set;}
	public double HitTime{get;set;}
	public double RechargeTime{get;set;}
	public int Level{get;set;}
	public long Exp{get;set;}
	

	public int HeroState{ get; set;}

	List<Effect> HeroEffects = new List<Effect>();

	private void ApplyEffects(){
		foreach (Effect currentEffect in HeroEffects) {
			switch(currentEffect.Stats){
			case (int)Stats.MaxHealthPoints:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					MaxHealthPoints += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);       //Is that right?
				}
				break;
			case (int)Stats.HealthPoints:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					HealthPoints += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.HealthRegen:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					HealthRegen += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.MaxManaPoints:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					MaxManaPoints += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.ManaPoints:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					ManaPoints += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.ManaRegen:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					ManaRegen += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.MoveSpeed:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					MoveSpeed+= currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.AttackPower:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					AttackPower += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.MagicPower:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					MagicPower += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.HitTime:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					HitTime += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.RechargeTime:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					RechargeTime += currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.Level:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					Level += (int)currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			case (int)Stats.Exp:
				if (Time.time < currentEffect.Beginning+currentEffect.Durability){
					Exp += (long)currentEffect.Doing;
				}else{
					HeroEffects.Remove(currentEffect);
				}
				break;
			}
		}
	}
	
//	public float speed = 10f;
//	
//	private float lastSynchronizationTime = 0f;
//	private float syncDelay = 0f;
//	private float syncTime = 0f;
//	private Vector3 syncStartPosition = Vector3.zero;
//	private Vector3 syncEndPosition = Vector3.zero;
//	
//
//	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
//	{
//		Vector3 syncPosition = Vector3.zero;
//		Vector3 syncVelocity = Vector3.zero;
//		if (stream.isWriting)
//		{
//			syncPosition = rigidbody.position;
//			stream.Serialize(ref syncPosition);
//			
//			syncVelocity = rigidbody.velocity;
//			stream.Serialize(ref syncVelocity);
//		}
//		else
//		{
//			stream.Serialize(ref syncPosition);
//			stream.Serialize(ref syncVelocity);
//			
//			syncTime = 0f;
//			syncDelay = Time.time - lastSynchronizationTime;
//			lastSynchronizationTime = Time.time;
//			
//			syncEndPosition = syncPosition + syncVelocity * syncDelay;
//			syncStartPosition = rigidbody.position;
//		}
//	}
//
//	private void SyncedMovement()
//	{
//		syncTime += Time.deltaTime;
//		
//		rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
//	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Effect{
	public int Stats{ get; set;}
	public double Doing{ get; set;}
	public long Beginning{ get; set;}
	public long Durability{ get; set;}
}

public enum Stats{
	MaxHealthPoints,
	HealthPoints,
	HealthRegen,
	MaxManaPoints,
	ManaPoints,
	ManaRegen,
	MoveSpeed,
	AttackPower,
	MagicPower,
	HitTime,
	RechargeTime,
	Level,
	Exp
}

public enum State{
	Stay,
	Going,
	Dead,
	Cast,
	Attack,
	Recharge
}
