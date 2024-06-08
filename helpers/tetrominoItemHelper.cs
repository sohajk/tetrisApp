using System;
using Godot;
using Godot.Collections;

[GlobalClass]
public partial class TetrominoItemHelper : Node
{
	public enum TetrominoType
	{
		I, O, T, J, L, S, Z
	}

	public static TetrominoType PickRandomTetrominoType()
	{
		var random = new Random();
		var types = Enum.GetValues(typeof(TetrominoType));
		var randomIndex = random.Next(types.Length);

		return (TetrominoType)types.GetValue(randomIndex);
	}

	public static Dictionary<TetrominoType, Vector2[]> Cells = new Dictionary<TetrominoType, Vector2[]>()
	{
		{ TetrominoType.I, new Vector2[] { new Vector2(-1, 0), new Vector2(0, 0), new Vector2(1, 0), new Vector2(2, 0) } },
		{ TetrominoType.J, new Vector2[] { new Vector2(1, 1), new Vector2(-1, 0), new Vector2(0, 0), new Vector2(1, 0) } },
		{ TetrominoType.L, new Vector2[] { new Vector2(-1, 1), new Vector2(-1, 0), new Vector2(0, 0), new Vector2(1, 0) } },
		{ TetrominoType.O, new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0) } },
		{ TetrominoType.S, new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(-1, 0), new Vector2(0, 0) } },
		{ TetrominoType.T, new Vector2[] { new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, 0), new Vector2(1, 0) } },
		{ TetrominoType.Z, new Vector2[] { new Vector2(-1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0) } }
	};

	public static Vector2[][] WallHitI = new Vector2[][]
	{
		new Vector2[] { new Vector2(0, 0), new Vector2(-2, 0), new Vector2(1, 0), new Vector2(-2, -1), new Vector2(1, 2) },
		new Vector2[] { new Vector2(0, 0), new Vector2(2, 0), new Vector2(-1, 0), new Vector2(2, 1), new Vector2(-1, -2) },
		new Vector2[] { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(2, 0), new Vector2(-1, 2), new Vector2(2, -1) },
		new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(-2, 0), new Vector2(1, -2), new Vector2(-2, 1) },
		new Vector2[] { new Vector2(0, 0), new Vector2(2, 0), new Vector2(-1, 0), new Vector2(2, 1), new Vector2(-1, -2) },
		new Vector2[] { new Vector2(0, 0), new Vector2(-2, 0), new Vector2(1, 0), new Vector2(-2, -1), new Vector2(1, 2) },
		new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(-2, 0), new Vector2(1, -2), new Vector2(-2, 1) },
		new Vector2[] { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(2, 0), new Vector2(-1, 2), new Vector2(2, -1) }
	};

	public static Vector2[][] WallHitJLOSTZ = new Vector2[][]
	{
		new Vector2[] { new Vector2(0, 0), new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(0, -2), new Vector2(-1, -2) }
	};

	public static Dictionary<TetrominoType, Resource> Data = new Dictionary<TetrominoType, Resource>()
	{
		{ TetrominoType.I, ResourceLoader.Load("res://resources/dataModelI.tres") },
		{ TetrominoType.J, ResourceLoader.Load("res://resources/dataModelJ.tres") },
		{ TetrominoType.L, ResourceLoader.Load("res://resources/dataModelL.tres") },
		{ TetrominoType.O, ResourceLoader.Load("res://resources/dataModelO.tres") },
		{ TetrominoType.S, ResourceLoader.Load("res://resources/dataModelS.tres") },
		{ TetrominoType.T, ResourceLoader.Load("res://resources/dataModelT.tres") },
		{ TetrominoType.Z, ResourceLoader.Load("res://resources/dataModelZ.tres") },
	};
}
