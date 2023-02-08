using Godot;
using System;

public class BomberPlaneMovement : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Vector2 velocity = new Vector2(-150, 0);
	private Sprite bomberSprite;
	private float damage = 1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bomberSprite = (Sprite)GetNode("BomberSprite");
		if(GlobalPosition.x < 0)
		{
			velocity = -(velocity);
			bomberSprite.FlipH = true;
		}
		if(GlobalPosition.y == -300)
		{
			velocity = 2 * velocity;
		}
		else if(GlobalPosition.y == -400)
		{
			velocity = 4 * velocity;
		}
	}

	public override void _Process(float delta)
	{
		velocity = MoveAndSlide(velocity);
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
