using Godot;
using System;

public class SpawnerController : Node2D
{
	private Spawner spawn;
	private int randCounter1 = 0; //Controls how random the spawning will be
	private int randCounter2 = 0;
	private int pace = 1000;
	
	public override void _Process(float delta)
	{
		uint random = (GD.Randi() % 3) + 1;
		randCounter1 += (int) random;
		randCounter2 += (int) random;
		if(randCounter1 > pace)
		{
			random = (GD.Randi() % 6) + 1;
			int spawnLoc = (int) random;
			setSpawner(spawnLoc);
			spawnItem(spawnLoc);
			randCounter1 = 0;
		}
		else if(randCounter2 > pace * 4)
		{
			random = (GD.Randi() % 6) + 7;
			int spawnLoc = (int) random;
			spawnItem(spawnLoc);
			randCounter2 = 0;
			if(pace > 400)
			{
				pace -= 100;
			}
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
			int test = (int)((GD.Randi() % 4) + 1);
			if(test == 2)
			{
				missile = (PackedScene)GD.Load("res://Missile2.tscn");
			}
			else if(test == 3)
			{
				missile = (PackedScene)GD.Load("res://Missile3.tscn");
			}
			else if(test == 4)
			{
				missile = (PackedScene)GD.Load("res://Missile4.tscn");
			}
			if(missile != null)
			{
				Missile missileFab = (Missile)missile.Instance();
				float math = 1;
				switch(test)
				{
					case 2:
						missileFab.setSpeed((math * (3/2))/60);
						break;
					case 3:
						missileFab.setSpeed((math/2)/60);
						break;
					case 4:
						missileFab.setSpeed(((math/4)*3)/60);
						break;
					default:
						break;
				}
				missileFab.GlobalPosition = spawn.GlobalPosition;
				AddChild(missileFab);
			}
		}
	}
}
