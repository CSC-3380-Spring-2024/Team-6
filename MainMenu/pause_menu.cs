using Godot;
using System;

public partial class pause_menu : Control
{
    CanvasLayer canvasLayer; 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Visible = false; 
        canvasLayer = GetNode<CanvasLayer>("CanvasLayer");
        canvasLayer.Visible = false; 
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        testEsc();
    }

    public void resume() {
        GetTree().Paused = false;
        Visible = false;
        canvasLayer.Visible = false; 
    }

    public void pause() {
        GetTree().Paused = true;
    }

    public void testEsc() {
        if(Input.IsActionJustPressed("esc") && !GetTree().Paused) 
        {
            Visible = true;
            pause();
            canvasLayer.Visible = true; 
            GD.Print("ESC1 Pressed");
        } else if(Input.IsActionJustPressed("esc") && GetTree().Paused) {
            Visible = false;
            canvasLayer.Visible = false; 
            resume();
            GD.Print("ESC2 Pressed");
        }
    }

    public void _on_resume_pressed() {
        resume();
    }

    public void _on_restart_pressed() {
        GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
        resume();
    }

    public void _on_quit_button_up() {
        GetTree().Quit();
    }
}
