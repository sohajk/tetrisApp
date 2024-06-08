using System.Collections.Generic;
using Godot;

public partial class Tetromino : Node2D
{
	private readonly double SPEED = 4000.0;
	private readonly double TIME_BETWEEN_MOVES = 1000.0;
	private double _timeLastMove = 0.0;

	public tetrominoModel Data { get; set; }
	public bool IsNextPiece { get; set; }

	private PackedScene _pieceScene;
	private Vector2[] _cells;
	private List<Piece> _pieces;
	private Vector2[][] _wallHits;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pieces = new List<Piece>();
		_pieceScene = (PackedScene)ResourceLoader.Load("res://scenes/piece.tscn");
		_cells = TetrominoItemHelper.Cells[Data.TetrominoType];

		foreach (var cell in _cells)
		{
			var pieceSceneInstance = (Piece)_pieceScene.Instantiate();
			pieceSceneInstance.Init();
			pieceSceneInstance.SetTexture(Data.PieceTexture);

			var pieceSize = pieceSceneInstance.GetSize();
			pieceSceneInstance.Position = cell * pieceSize;
			pieceSceneInstance.Position += Data.SpawnPosition;

			// Move to center
			pieceSceneInstance.Position += new Vector2(2 * pieceSize.X, 1);

			_pieces.Add(pieceSceneInstance);
			AddChild(pieceSceneInstance);
		}

		if (!IsNextPiece)
		{
			Position = Data.SpawnPosition;
			_wallHits = Data.TetrominoType == TetrominoItemHelper.TetrominoType.I ? TetrominoItemHelper.WallHitI : TetrominoItemHelper.WallHitJLOSTZ;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var shift = ControlHandler();

		_timeLastMove += delta * SPEED;

		if (shift != default && _timeLastMove >= TIME_BETWEEN_MOVES)
		{
			_timeLastMove = 0;
			Move(shift);
		}
	}

	private Vector2 ControlHandler()
	{
		if (Input.IsKeyPressed(Key.Right))
		{
			return Vector2.Right;
		}
		else if (Input.IsKeyPressed(Key.Down))
		{
			return Vector2.Down;
		}
		else if (Input.IsKeyPressed(Key.Left))
		{
			return Vector2.Left;
		}

		return default;
	}

	private Dictionary<string, int> bounds = new Dictionary<string, int>()
	{
		["min_x"] = -216,
		["max_x"] = 216,
		["max_y"] = 457
	};

	private void Move(Vector2 shift)
	{
		GlobalPosition += (shift * 48);
	}
}
