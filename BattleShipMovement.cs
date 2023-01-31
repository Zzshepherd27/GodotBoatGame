using Godot;
using System;

public class BattleShipMovement : KinematicBody2D
{
	[Export] public int speed = 200;
	
	public Vector2 velocity = new Vector2();
	Sprite boat;
	
	public override void _Ready()
	{
		boat = (Sprite)GetNode("Battlecrip");
	}
	
	public void GetInput()
	{
		velocity = new Vector2();
		if (Input.IsActionPressed("right"))
		{
			velocity.x += 1;
			boat.FlipH = false;
		}
		if (Input.IsActionPressed("left"))
		{
			velocity.x -= 1;
			boat.FlipH = true;
		}
		velocity = velocity.Normalized() * speed;
	}
	
	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		velocity = MoveAndSlide(velocity);
	}
}
