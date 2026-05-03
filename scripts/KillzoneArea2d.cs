using Godot;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public partial class KillzoneArea2d : Area2D
{
	[Export]
	private Timer _timer; // Drag the Timer node here in the Editor

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		_timer.Timeout += OnTimerTimeout;
	}

	// Am manually setting the player's collision layer to 2, so this will only trigger when the player enters the area.
	// For this to register, the CoinArea2d's collision layer must be set to 1 and its collision mask must include layer 2.
	private void OnBodyEntered(Node body)
	{
		// Example: Check if it's the player
		if (body is PlayerCharacterBody2d player)
		{
			Engine.TimeScale = 0.5;
			GD.Print("Player died!");

			player.Die();
			_timer.Start();
		}
	}

	private void OnTimerTimeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
	}
}
