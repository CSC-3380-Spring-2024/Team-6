using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	public const float Speed = 150.0f;
	public const float JumpVelocity = -300.0f;

	private int dashSpeed = 300;

	private bool isDashing = false;

	private float dashTimer = .2f;

	private float dashTimerReset = .2f;

	private bool canClimb = true;

	private int climbSpeed = 100;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	
	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 velocity = Velocity;

		
		// Add the gravity.
		if (!IsOnFloor()){}
			velocity.Y += gravity * (float)delta;
			canClimb = true;
			

		// Handle Jump.
		if (Input.IsActionPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;
			
			

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if(!isDashing){

			if (direction != Vector2.Zero)
			{
				velocity.X = direction.X * Speed;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}
		}


		if(Input.IsActionPressed("dash")){ //dashing

			if(Input.IsActionPressed("ui_left")){
				velocity.X = -dashSpeed;
				isDashing = true;
			}
			if(Input.IsActionPressed("ui_right")){
				velocity.X = dashSpeed;
				isDashing = true;
			}
			if(Input.IsActionPressed("ui_up")){
				velocity.Y = -dashSpeed;
				isDashing = true;
			}
			if(Input.IsActionPressed("ui_right") && Input.IsActionPressed("ui_up")){
				velocity.X = dashSpeed;
				velocity.Y = -dashSpeed;
				isDashing = true;
			}
			if(Input.IsActionPressed("ui_left") && Input.IsActionPressed("ui_up")){
				velocity.X = -dashSpeed;
				velocity.Y = -dashSpeed;
				isDashing = true;
			}

			dashTimer = dashTimerReset;


		}
		if(isDashing){
			float myFloatDelta = Convert.ToSingle(delta); //conversion double to float for dashTimer

			dashTimer -= myFloatDelta;
			if(dashTimer <= 0){
				isDashing = false;
				velocity = new Vector2(0,0); //stops the slding when dashing
			}
		}


		if(Input.IsActionPressed("climb") && (GetNode<RayCast2D>("RayCastLeft").IsColliding() || GetNode<RayCast2D>("RayCastRight").IsColliding() || 
		GetNode<RayCast2D>("RayCastRightClimb").IsColliding() || GetNode<RayCast2D>("RayCastLeftClimb").IsColliding() )){    //wallclimbing
			if(canClimb){
				if(Input.IsActionPressed("ui_up")){
					velocity.Y = -climbSpeed;
				}
				else if(Input.IsActionPressed("ui_down")){
					velocity.Y = climbSpeed;
				}
				else{
					velocity = new Vector2(0,0);
				}

			}
		}
	

		Velocity = velocity;
		MoveAndSlide();
	}

	private void processClimb(float delta){
		
	}
}

