using Godot;
using System;

public class SpawnerController : Node2D
{
	private Spawner spawn;
	private int randCounter1 = 0; //Controls how random the spawning will be
	private int randCounter2 = 0;
	
	public override void _Process(float delta)
	{
		uint random = (GD.Randi() % 3) + 1;
		randCounter1 += (int) random;
		randCounter2 += (int) random;
		if(randCounter1 > 400)
		{
			random = (GD.Randi() % 6) + 1;
			int spawnLoc = (int) random;
			setSpawner(spawnLoc);
			spawnItem(spawnLoc);
			randCounter1 = 0;
		}
		else if(randCounter2 > 1600)
		{
			random = (GD.Randi() % 6) + 7;
			int spawnLoc = (int) random;
			spawnItem(spawnLoc);
			randCounter2 = 0;
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
		if(sl > 6)
		{
			PackedScene bomberPlane = (PackedScene)GD.Load("res://BomberPlane.tscn");
			if(bomberPlane != null)
			{
				KinematicBody2D bomberFab = (KinematicBody2D)bomberPlane.Instance();
				bomberFab.GlobalPosition = spawn.GlobalPosition;
				AddChild(bomberFab);
			}
		}
		else if(sl < 7)
		{
			PackedScene missile = (PackedScene)GD.Load("res://Missile.tscn");
			if(missile != null)
			{
				RigidBody2D missileFab = (RigidBody2D)missile.Instance();
				missileFab.GlobalPosition = spawn.GlobalPosition;
				AddChild(missileFab);
			}
		}
	}
}