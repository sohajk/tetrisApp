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

	public static Dictionary<TetrominoType, Resource> Data = new Dictionary<TetrominoType, Resource>()
	{
		{ TetrominoType.I, ResourceLoader.Load("res://resources/dataModelI.tres") },
	};
}
