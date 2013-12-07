using UnityEngine;
using System.Collections.Generic;

public class HandleAttack 
{

	void StartAttack(Player attacker)
	{

	}

	[RPC]
	void CountDamage (Player attacker, List<Player> victims) 
	{
		if (victims.Count == 0) 
		{
			return;
		}
		foreach (var victim in victims) 
		{
			//if(IsOnAttackPosition(victim.rigidbody.position, attacker.rigidbody.position, attacker.Range))
			//{
			//	victim.Health -= attacker.CountDamage();
			//	victim.CheckStatus();
			//	victim.OnUpdateFromServer();
			//}
		}
	}

	bool IsOnAttackPosition(Vector3 pos1, Vector3 pos2, double range)
	{
		double delta = Mathf.Sqrt ((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.z - pos2.z) * (pos1.z - pos2.z));
		if (delta > range)
						return false;
				else
						return true;
	}

}
