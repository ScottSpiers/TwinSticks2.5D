using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour 
{
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	/// <summary>
	/// Sets the master volume.
	/// </summary>
	/// <param name="vol">The user's selected volume</param>
	public static void SetMasterVolume(float vol)
	{
		if(vol >= 0 && vol <= 1)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, vol);
		}
		else
		{
			Debug.LogError("Master Volume Out of Range");
		}
	}
	
	/// <summary>
	/// Gets the master volume.
	/// </summary>
	/// <returns>The master volume.</returns>
	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	/// <summary>
	/// Sets the difficulty.
	/// </summary>
	/// <param name="difficulty">The user's selected difficulty.</param>
	public static void SetDifficulty(int difficulty)
	{
		if(difficulty >= 1 && difficulty <= 3)
		{
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		}
		else
		{
			Debug.LogError("Difficulty Out of Range");
		}
	}
	
	/// <summary>
	/// Gets the difficulty.
	/// </summary>
	/// <returns>The difficulty.</returns>
	public static int GetDifficulty()
	{
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}
	
	/// <summary>
	/// Unlocks the level.
	/// </summary>
	/// <param name="level">The last level which has bene unlocked</param>
	public static void UnlockLevel(int level)
	{
		if(IsLevel(level))
		{
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
		}
	}
	
	public static bool IsLevelUnlocked(int level)
	{
		if(IsLevel(level))
		{
			return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1);
		}
		return false;
	}
	
	/// <summary>
	/// Checks the specified level is in the build order.
	/// </summary>
	/// <returns><c>true</c>, if level exists, <c>false</c> otherwise.</returns>
	/// <param name="level">The level being checked</param>
	private static bool IsLevel(int level)
	{
		if(level <= SceneManager.sceneCountInBuildSettings - 1)
		{
			return true;
		}
		else
		{
			Debug.LogError("Level Does Not Exist in Build Order");
			return false;
		}		
	}
}