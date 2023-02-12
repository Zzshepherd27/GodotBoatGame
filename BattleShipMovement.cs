using Godot;
using System;

public class BattleShipMovement : KinematicBody2D
{
	[Export] public int speed = 300;
	
	private Vector2 velocity = new Vector2();
	private Sprite boat;
	
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
			Audio world = (Audio)GetNode("/root/Stage/Audio");
			AudioStreamPlayer2D au = (AudioStreamPlayer2D)GetNode("Boat Audio");
			world.audioBasic(au);
		}
		if (Input.IsActionPressed("left"))
		{
			velocity.x -= 1;
			boat.FlipH = true;
			Audio world = (Audio)GetNode("/root/Stage/Audio");
			AudioStreamPlayer2D au = (AudioStreamPlayer2D)GetNode("Boat Audio");
			world.audioBasic(au);
		}
		velocity = velocity.Normalized() * speed;
		if(velocity == new Vector2(0,0))
		{
			AudioStreamPlayer2D au = (AudioStreamPlayer2D)GetNode("Boat Audio");
			au.Playing = false;
		}
	}
	
	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		velocity = MoveAndSlide(velocity);
	}

}
