using Godot;
using System;

public partial class GazeOverlay : ColorRect
{

	[Export]
	private float _radius = 30.0f;
	private ShaderMaterial _shader;
	private Vector2 _mousePos;

	private void UpdateMousePosition()
	{
		_mousePos = GetLocalMousePosition();
	}
	public override void _Ready()
	{
		_shader = Material as ShaderMaterial;

		if (_shader == null)
		{
			GD.Print("GazeOverlay: No ShaderMaterial assigned in the Inspector!");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateMousePosition();
		_shader?.SetShaderParameter("gaze_position", _mousePos);
		_shader?.SetShaderParameter("rect_size", Size);
		_shader?.SetShaderParameter("radius", _radius);
	}
}
