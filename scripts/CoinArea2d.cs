using Godot;
using System;
using System.Runtime.InteropServices.JavaScript;

public partial class CoinArea2d : Area2D
{
	// Project Settings -> Globals -> AutoLoad -> Add "GameManager" (scripts/GameManager.cs) to make it globally accessible.
	private GameManager _gameManager;

	[Export]
	private AnimationPlayer _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager ??= GetTree().Root.FindChild("GameManager", true, false) as GameManager;
		if (_gameManager == null)
			GD.PushWarning("CoinArea2d: GameManager not found — assign it in the editor or add a GameManager node to the scene.");

		BodyEntered += OnBodyEntered;
	}

	// Am manually setting the player's collision layer to 2, so this will only trigger when the player enters the area.
	// For this to register, the CoinArea2d's collision layer must be set to 1 and its collision mask must include layer 2.
	private void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D)
		{
			_gameManager?.AddPoint();
			_player.Play("pickup");
			//QueueFree();
		}
	}

	// Called ever y frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
