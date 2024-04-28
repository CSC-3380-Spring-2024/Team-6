using Godot;
using System;

public partial class healthBar : Control
{
    private TextureProgressBar HealthProgressBar;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HealthProgressBar = GetNode<TextureProgressBar>("CanvasLayer/HealthProgressBar");
		
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

	private void _on_player_health_changed(int newHealth){
		HealthProgressBar.Value=newHealth;
	}
}
