using Godot;
using System;

public partial class main_menu : Control
{

	private MarginContainer options;
	private MarginContainer mainDefault;
	private Sprite2D sprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
			GetNode<AnimationPlayer>("Sprite2D/AnimationPlayer").Play("Movement");
			options = GetNode<MarginContainer>("Options");
			mainDefault = GetNode<MarginContainer>("mainDefault");
			mainDefault.Visible = true;
			options.Visible = false;
			sprite = GetNode<Sprite2D>("Sprite2D");
			sprite.Visible = true;
			
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		if(Input.IsActionJustPressed("esc") && options.Visible){
			options.Visible = false;
			mainDefault.Visible=true;
		} 
	}


	public void _on_play_button_up() {
		GetTree().ChangeSceneToFile("res://Level1/level1.tscn");
	}

	public void _on_options_button_up() {
		options.Visible=true;	
		mainDefault.Visible=false;
		sprite.Visible = false;
	}

	public void _on_quit_button_up() {
		GetTree().Quit();
	}
	public void _on_back_button_up(){
		sprite.Visible = true;
		options.Visible = false;
		mainDefault.Visible=true;
	}
	
}
