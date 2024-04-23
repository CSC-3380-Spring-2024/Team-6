using Godot;
using System;

public partial class main_menu : Control
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
				GetNode<AnimationPlayer>("Sprite2D/AnimationPlayer").Play("Movement");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	}


	public void _on_play_button_up() {
		GetTree().ChangeSceneToFile("res://Level1/level1.tscn");
	}

	public void _on_options_button_up() {
		GetTree().ChangeSceneToFile("res://Level1/level1.tscn");
		
	}

	public void _on_quit_button_up() {
		GetTree().Quit();
	}
}
