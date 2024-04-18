using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -600.0f;

	private int dashSpeed = 300;

	private bool isDashing = false;

	private float dashTimer = .2f;

	private float dashTimerReset = .2f;

	private bool isDashAvailable = true; 

	private bool canClimb = true;

	private int climbSpeed = 100;

	private bool isClimbing = false;

	private float climbTimer = 5f; 

	private float climbTimerReset = 5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	
	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 velocity = Velocity;

		
		// Add the gravity.
		if (!IsOnFloor()){
			velocity.Y += gravity * ((float)delta);
			canClimb = true;
			isDashAvailable = true;
			
		}

		// Handle Jump.
		if(IsOnFloor()){
			if(Input.IsActionPressed("ui_accept")){
				velocity.Y = JumpVelocity;
				
			}
			canClimb = true;
			isDashAvailable = true;
		}
		
		

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

		if(isDashAvailable){

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


		}
		if(isDashing){
			float myFloatDelta = Convert.ToSingle(delta); //conversion double to float for dashTimer

			dashTimer -= myFloatDelta;
			if(dashTimer <= 0){
				isDashing = false;
				velocity = new Vector2(0,0); //stops the slding when dashing
			}
		} 
		else if(!isClimbing){
			velocity.Y += gravity * (float)delta; 
		}else{
			climbTimer -= (float)delta;
			if(climbTimer <= 0){
				isClimbing = false;
				canClimb = false; 
				climbTimer = climbTimerReset;
			}
		}


		if(Input.IsActionPressed("climb") && (GetNode<RayCast2D>("RayCastLeft").IsColliding() || GetNode<RayCast2D>("RayCastRight").IsColliding() || 
		GetNode<RayCast2D>("RayCastRightClimb").IsColliding() || GetNode<RayCast2D>("RayCastLeftClimb").IsColliding() )){    //wallclimbing
			if(canClimb){
				isClimbing = true;
				if(Input.IsActionPressed("ui_up")){
					velocity.Y = -climbSpeed;
				}
				else if(Input.IsActionPressed("ui_down")){
					velocity.Y = climbSpeed;
				}
				else{
					velocity = new Vector2(0,0);
				}

			}else{
				isClimbing = false;
			}

		}else{
			isClimbing = false;
		}
	

		Velocity = velocity;
		MoveAndSlide();
	}

	private void processClimb(float delta){
		
	}
}

