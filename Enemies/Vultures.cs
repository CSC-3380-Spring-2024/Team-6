using Godot;
using System;

public class Vulture : CharacterBody2D
{
	private const int Speed = 100;
	private const float DetectionRadius = 200;

	private Vector2 _velocity = Vector2.Zero;
	private Node2D _player = null;
	private Area2D _detectionArea;

	public override void _Ready()
	{
		_detectionArea = GetNode("DetectionArea") as Area2D;
		_detectionArea.Connect("body_entered", this, "_on_detection_area_body_entered");
		_detectionArea.Connect("body_exited", this, "_on_detection_area_body_exited");
	}

	public override void _PhysicsProcess(float delta)
	{
		if (_player != null)
		{
			Vector2 direction = (_player.GlobalPosition - GlobalPosition).Normalized();
			_velocity = direction * Speed * delta;
			MoveAndSlide(_velocity);
		}
	}

	private void _on_detection_area_body_entered(Node body)
	{
		if (body is Player)
		{
			_player = (Node2D)body;
		}
	}

	private void _on_detection_area_body_exited(Node body)
	{
		if (body == _player)
		{
			_player = null;
		}
	}
}
