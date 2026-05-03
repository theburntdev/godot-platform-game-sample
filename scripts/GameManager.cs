using Godot;
using System;

public partial class GameManager : Node
{
	/// <summary>
	/// No Export here and no Editor to assign... The reason is because I made GameManager an Autoload Global variable
	/// the traditional export/editor assignment doesn't work well with Autoloads. 
	/// Instead, we find the ScoreLabel at runtime in the _Ready method.
	/// 
	/// When a node is set up as an Autoload, Godot creates it separately from your main scene 
	/// — it lives under /root/GameManager, not inside your scene tree
	/// </summary>
	private Label _scoreLabel;

	public int Score = 0;

	public override void _Ready()
	{
		_scoreLabel ??= GetTree().Root.FindChild("ScoreLabel", true, false) as Label;
		if (_scoreLabel == null)
			GD.PushWarning("GameManager: ScoreLabel not found — assign it in the editor or check the node name.");
	}

	public void AddPoint()
	{
		Score++;
		GD.Print($"Score: {Score}");
		if (_scoreLabel != null)
			_scoreLabel.Text = $"You collected {Score} coins.";
	}

}
