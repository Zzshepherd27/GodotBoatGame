using Godot;
using System;

public class Missile : RigidBody2D
{
	private Vector2 velocity = new Vector2();
	private Vector2 direction;
	private Vector2 origin = new Vector2(0,0);

	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		uint randX = (GD.Randi() % 500) + 1;
		uint randY = (GD.Randi() % 150) + 1;
		int impX = (int) randX;
		int impY = (int) randY;
		if(GD.Randi() % 2 == 1)
		{
			impY = impY * -1;
		}
		if(Position.x == 500)
		{
			impX = impX * -1;
		}
		Vector2 imp = new Vector2(impX, impY);
		ApplyCentralImpulse(imp);
	}
	
	public override void _Process(float delta)
	{
		direction = new Vector2(velocity.x, velocity.y).Normalized();
		float angle = direction.Angle();
		this.GlobalRotation = Mathf.LerpAngle(this.GlobalRotation, angle, delta);
	}

	public void applyImp(Vector2 imp)
	{
		this.ApplyCentralImpulse(imp);
	}
}
