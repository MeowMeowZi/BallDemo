using UnityEngine;
using QFramework;

namespace BallDemo
{
	public partial class Brick : ViewController
	{
		public void BeAtk(float damage)
		{
			Destroy(gameObject);
		}
	}
}
