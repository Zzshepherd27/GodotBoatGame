using Godot;
using System;

public class Missile : RigidBody2D
{
	private Vector2 velocity = new Vector2();
	private Vector2 direction;
	private Vector2 offset = new Vector2(0,0);

	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		for(int i = 1; i <= 6; i++)
		{
			Spawner sp = (Spawner)GetNode("/root/Stage/MissileControl/SpawnLoc" + i);
			if(this.Position.x == sp.Position.x && this.Position.y == sp.Position.y)
			{
				ApplyImpulse(offset, sp.getSpawnerForce());
			}
		}
	}
	
	public override void _Process(float delta)
	{
		/*direction = new Vector2(velocity.x, velocity.y).Normalized();
		float angle = direction.Angle();
		this.GlobalRotation = Mathf.LerpAngle(this.GlobalRotation, angle, delta);*/
	}

	
}
