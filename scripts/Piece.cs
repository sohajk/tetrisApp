using Godot;

public partial class Piece : Area2D
{
	private Sprite2D _piece;
	private CollisionShape2D _collisionShape;

	public void Init()
	{
		_piece = GetNode<Sprite2D>("./Piece");
		_collisionShape = GetNode<CollisionShape2D>("./CollisionShape2D");
	}

	public void SetTexture(Texture2D texture)
	{
		_piece.Texture = texture;
	}

	public Vector2 GetSize()
	{
		return _collisionShape.Shape.GetRect().Size;
	}
}
