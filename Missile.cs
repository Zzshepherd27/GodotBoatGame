using Godot;
using System;

public class Missile : RigidBody2D
{
	private Vector2 direction;
	private Vector2 offset = new Vector2(0,0);
	private float damage = 100;
	private bool backwardsRotation = false;

	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		for(int i = 1; i <= 6; i++)
		{
			Spawner sp = (Spawner)GetNode("/root/Stage/SpawnerController/SpawnLoc" + i);
			if(this.Position.x == sp.Position.x && this.Position.y == sp.Position.y)
			{
				ApplyImpulse(offset, sp.getSpawnerForce());
				if(sp.Position.x > 0)
				{
					backwardsRotation = true;
				}
			}
		}
	}
	
	public override void _IntegrateForces(Physics2DDirectBodyState state)
	{
		direction = new Vector2(LinearVelocity.x, LinearVelocity.y).Normalized();
		float angle = Mathf.Rad2Deg(Mathf.Asin(direction.y));
		if(backwardsRotation)
		{
			this.RotationDegrees = -(angle - 90);
		}
		else
		{
			this.RotationDegrees = angle - 90;
		}
	}

	public void setDamage(float dmg)
	{
		damage = dmg;
	}
	
	public float getDamage()
	{
		return damage;
	}
	
}
