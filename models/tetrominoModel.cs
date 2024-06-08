using Godot;

[GlobalClass]
public partial class tetrominoModel : Resource
{
	[Export]
	public Texture2D PieceTexture {get; set;}

	[Export]
	public TetrominoItemHelper.TetrominoType TetrominoType {get; set;}

	[Export]
	public Vector2 SpawnPosition {get; set;}
}
