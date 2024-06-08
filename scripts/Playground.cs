using Godot;

public partial class Playground : TextureRect
{
	private PackedScene _tetrominoScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SpawnTetromino(TetrominoItemHelper.TetrominoType currentTetrominoType)
	{
		var tetrominoData = TetrominoItemHelper.Data[currentTetrominoType];
		_tetrominoScene = (PackedScene)ResourceLoader.Load("res://scenes/snake_body_part.tscn");
	}
}
