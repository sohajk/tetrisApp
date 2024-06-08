using Godot;

public partial class Playground : TextureRect
{
	private PackedScene _tetrominoScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_tetrominoScene = (PackedScene)ResourceLoader.Load("res://scenes/tetromino.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SpawnTetromino(TetrominoItemHelper.TetrominoType currentTetrominoType, bool isNextPiece)
	{
		// var tetrominoData = TetrominoItemHelper.Data[currentTetrominoType] as tetrominoModel;
		var tetrominoData = TetrominoItemHelper.Data[TetrominoItemHelper.TetrominoType.I] as tetrominoModel;

		var tetrominoSceneInstance = (Node)_tetrominoScene.Instantiate() as Tetromino;
		tetrominoSceneInstance.Data = tetrominoData;
		tetrominoSceneInstance.IsNextPiece = isNextPiece;

		if (!isNextPiece)
		{
			tetrominoSceneInstance.Position = tetrominoData.SpawnPosition;
			AddChild(tetrominoSceneInstance);
		}
	}
}
