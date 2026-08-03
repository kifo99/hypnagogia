using Godot;
using System;

public partial class FOVManager : Node2D
{
	[Export]
	private float _radius = 30;
	[Export]
	private float _startAngle = 0;
	[Export]
	private float _endAngle = MathF.Tau;
	[Export]
	private int _pointCount = 32;
	[Export]
	private Color _color;
	[Export]
	private bool _antialiased = false;
	private Vector2 _mousePos;

	public override void _Process(double delta)
	{
		UpdateMousePosition();
	}

	private void UpdateMousePosition()
	{
		_mousePos = GetLocalMousePosition();
		QueueRedraw();
	}

	public override void _Draw()
	{
		DrawArc(_mousePos, _radius, _startAngle, _endAngle, _pointCount, _color, 1.0f, _antialiased);
	}
}
