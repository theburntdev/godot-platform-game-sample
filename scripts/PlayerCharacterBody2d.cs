using Godot;
using System;

public partial class PlayerCharacterBody2d : CharacterBody2D
{
	[Export]
	private CollisionShape2D _collisionShape;

	[Export]
	private AnimatedSprite2D _animatedSprite;

	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		// INFO: Godot -> Project -> Project Settings -> Input Map -> Add "jump" action and assign a key (e.g., Space).
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");

		// Flip the sprite based on the movement direction.
		if (direction.X > 0)
		{
			_animatedSprite.FlipH = false;
		}
		else if (direction.X < 0)
		{
			_animatedSprite.FlipH = true;
		}

		// Animations
		if (IsOnFloor())
		{
			if (direction.X == 0)
			{
				_animatedSprite.Play("idle");
			}
			else
			{
				_animatedSprite.Play("run");
			}
		}
		else
		{
			_animatedSprite.Play("jump");
		}

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void Die()
	{
		_collisionShape.QueueFree();
	}
}
