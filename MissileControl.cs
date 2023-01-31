using Godot;
using System;

public class MissileControl : Node2D
{
	private Spawner spawn;
	public int randCounter = 0; //Controls how random the spawning will be
	
	public override void _Process(float delta)
	{
		uint check = (GD.Randi() % 3) + 1;
		randCounter += (int) check;
		if(randCounter > 400)
		{
			check = (GD.Randi() % 6) + 1;
			int spawnLoc = (int) check;
			setSpawner(spawnLoc);
			spawnItem(spawnLoc);
			randCounter = 0;
		}
	}
	
	public void setSpawner(int sl)
	{
		uint random = 0;
		if((Spawner)GetNode("SpawnLoc" + sl) != null)
		{
			spawn = (Spawner)GetNode("SpawnLoc" + sl);
			if(spawn.Position.y < -200)
			{
				random = GD.Randi() % 30 + 1;
				spawn.setAngle((float) random);
			} 
			else
			{
				while((float) random < 30)
				{
					random = GD.Randi() % 60 + 1;
					spawn.setAngle((float) random);
				}
				random = 0;
			}
			if(spawn.Position.x == 500)
			{
				spawn.setAngle(180 - spawn.getAngle());
			}
			spawn.setSpawnerForce(400);
		}
	}

	public void spawnItem(int sl)
	{
		spawn = (Spawner)GetNode("SpawnLoc" + sl);
		PackedScene missile = (PackedScene)GD.Load("res://Missile.tscn");
		if(missile != null)
		{
			RigidBody2D missileFab = (RigidBody2D)missile.Instance();
			missileFab.GlobalPosition = spawn.GlobalPosition;
			AddChild(missileFab);
		}
	}
}
