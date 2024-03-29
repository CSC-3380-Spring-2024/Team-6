using Godot;
using System;

public partial class pause_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		testEsc();
	}

	public void resume() {
		GetTree().Paused = false;
	}

	public void pause() {
		GetTree().Paused = true;
	}

	public void testEsc() {
		if(Input.IsActionJustPressed("esc") && GetTree().Paused == false) 
		{
			pause();
			GD.Print("ESC1 Pressed");
		}

		if(Input.IsActionJustPressed("esc") && GetTree().Paused == true) {
			resume();
			GD.Print("ESC2 Pressed");
		}
	}

	public void _on_resume_pressed() {
		resume();
	}

	public void _on_restart_pressed() {
		GetTree().ReloadCurrentScene();
	}

	public void _on_quit_button_up() {
		GetTree().Quit();
	}
}


