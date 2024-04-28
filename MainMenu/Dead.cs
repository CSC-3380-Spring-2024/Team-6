using Godot;
using System;

public partial class Dead : Control
{

	int health = 100;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		health=100;
		GetNode<CanvasLayer>("CanvasLayer").Visible=false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(health < 1) {
		GetNode<CanvasLayer>("CanvasLayer").Visible=true;			
		GD.Print("Health: " + health);
		}
	}
	
	private void _on_player_health_changed(int newHealth){
		health=newHealth;
	}

	public void _on_restart_button_up() {
		GetNode<CanvasLayer>("CanvasLayer").Visible=false;
		GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
	}

	public void _on_main_button_up() {
		GetTree().ChangeSceneToFile("res://MainMenu/main_menu.tscn");
	}

	public void _on_quit_button_up() {
		GetTree().Quit();
	}
}
