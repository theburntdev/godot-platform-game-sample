using Godot;
using System;

public partial class SlimeNode2d : Node2D
{
	const int SPEED = 50;
	private int _direction = 1;

	/// <summary>
	/// Export is the way to go...You have to have godot build first before it knows these are assignable in the editor
	/// </summary>
	[Export]
	private RayCast2D _left;

	[Export]
	private RayCast2D _right;

	[Export]
	private AnimatedSprite2D _animatedSprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_right.IsColliding())
		{
			_direction = -1;
			_animatedSprite2D.FlipH = true;
		}
		else if (_left.IsColliding())
		{
			_direction = 1;
			_animatedSprite2D.FlipH = false;
		}
		
		// Position is a struct (value type). Modify a copy and assign it back.
		Position = new Vector2(Position.X + (_direction * SPEED * (float)delta), Position.Y);
	}
}
