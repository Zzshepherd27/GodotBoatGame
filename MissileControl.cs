using Godot;
using System;

public class MissileControl : Node2D
{
	private Node2D spawn;
	public int randCounter = 0; //Controls how random the spawning will be
	
	public override void _Process(float delta)
	{
		uint check = (GD.Randi() % 3) + 1;
		randCounter += (int) check;
		if(randCounter > 400)
		{
			check = (GD.Randi() % 6) + 1;
			int spawnLoc = (int) check;
			spawnItem(spawnLoc);
			randCounter = 0;
		}
	}

	public void spawnItem(int sl)
	{
		spawn = (Node2D)GetNode("SpawnLoc" + sl);
		PackedScene missile = (PackedScene)GD.Load("res://Missile.tscn");
		if(missile != null)
		{
			RigidBody2D missileFab = (RigidBody2D)missile.Instance();
			missileFab.GlobalPosition = spawn.GlobalPosition;
			AddChild(missileFab);
			uint randX = (GD.Randi() % 500) + 1;
			uint randY = (GD.Randi() % 150) + 1;
			int impX = (int) randX;
			int impY = (int) randY;
			if(GD.Randi() % 2 == 1)
			{
				impY = impY * -1;
			}
			if(missileFab.Position.x == 500)
			{
				impX = impX * -1;
			}
			Vector2 imp = new Vector2(impX, impY);
			missileFab.ApplyCentralImpulse(imp);
			Node2D ship = (Node2D)GetNode("/root/Stage/BattleShip");
			missileFab.SetRotation(missileFab.GetRotation() + 90);
		}
	}
}
