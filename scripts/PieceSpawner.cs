using Godot;

public partial class PieceSpawner : Node
{
	private TetrominoItemHelper.TetrominoType _currentTetrominoType;

	[Export]
	private NodePath _playgroundPath;
	private Playground _playground;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_currentTetrominoType = TetrominoItemHelper.PickRandomTetrominoType();

		_playground = GetNode<Playground>("../PlaygroundWrapper/Playground");
		_playground.SpawnTetromino(_currentTetrominoType, false);
	}


}
