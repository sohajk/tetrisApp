using Godot;

public partial class PieceSpawner : Node
{
	private TetrominoItemHelper.TetrominoType _currentTetrominoType;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_currentTetrominoType = TetrominoItemHelper.PickRandomTetrominoType();
	}


}
