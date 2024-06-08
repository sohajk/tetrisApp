using System.Collections.Generic;
using Godot;

public partial class Tetromino : Node2D
{
	public tetrominoModel Data { get; set; }
	public bool IsNextPiece { get; set; }

	private PackedScene _pieceScene;
	private Vector2[] _cells;
	private List<Piece> _pieces;

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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
