using Godot;
using System;

public class Vulture : CharacterBody2D
{
	private int speed = 35;
	private bool playerChase = false;
	private Node2D player = null;

	public override void _PhysicsProcess(float delta)
	{
		if (playerChase && player != null)
		{
			Position += (player.Position - Position) / speed * delta;
		}
	}

	private void _on_detection_area_body_entered(Node2D body)
{
	player = (Node2D)body;
		playerChase = true;
}


	
private void _on_detection_area_body_exited(Node2D body)
{
	 player = null;
		playerChase = false;
}

	


