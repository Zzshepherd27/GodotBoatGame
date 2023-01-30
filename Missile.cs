using Godot;
using System;

public class Missile : RigidBody2D
{
	private Vector2 velocity = new Vector2();
	

	// Called when the node enters the scene tree for the first time.
	public override void _PhysicsProcess(float delta)
	{
		
	}

	public void applyImp(Vector2 imp)
	{
		this.ApplyCentralImpulse(imp);
	}
}
