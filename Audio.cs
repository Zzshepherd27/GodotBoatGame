using Godot;
using System;

public class Audio : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private AudioStreamPlayer2D audio;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	
	public void audioBasic(AudioStreamPlayer2D au)
	{
		if(au != null)
		{
			audio = au;
			if(audio.Playing != true)
			{
				audio.Play();
			}
		}
	}
	
}
