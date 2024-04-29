using Godot;
using System;
using System.Threading;

public partial class Label : Godot.Label
{
	private int _score = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OnMobKilled();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void OnMobKilled(){
		Text = "Score: 3380";
	}
}
