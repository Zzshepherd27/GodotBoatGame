using Godot;
using System;

public class Spawner : Node2D
{
	
	private float angle;
	private Vector2 spawnerForce;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(angle == 0)
		{
			angle = 30;
		}
		if(spawnerForce == null)
		{
			spawnerForce = new Vector2(0, 0);
		}
	}

	public float getAngle()
	{
		return angle;
	}
	
	public void setAngle(float ag)
	{
		angle = ag;
	}
	
	public Vector2 getSpawnerForce()
	{
		return spawnerForce;
	}
	
	public void setSpawnerForce(float magnitude)
	{
		float unitY = Mathf.Sin(Mathf.Deg2Rad(angle));
		float unitX = Mathf.Cos(Mathf.Deg2Rad(angle));
		Vector2 unitVector = new Vector2(unitX, -unitY);
		spawnerForce = unitVector * magnitude;
	}
	
}
