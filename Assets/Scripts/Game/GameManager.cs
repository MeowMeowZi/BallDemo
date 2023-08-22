using System;
using UnityEngine;
using QFramework;

namespace BallDemo
{
	public partial class GameManager : ViewController
	{
		private ResLoader mResLoader;
		
		private void Awake()
		{
			mResLoader = ResLoader.Allocate();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				CreateBall();
			}
		}

		private Ball CreateBall()
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 dir = (mousePos - (Vector2)ShootPos.position).normalized;
			
			GameObject ballGo = mResLoader.LoadSync<GameObject>(QAssetBundle.Ball_prefab.BALL);
			Ball ball = Instantiate(ballGo, ShootPos.position, Quaternion.identity).GetComponent<Ball>();
			ball.OnInit(dir);
			return ball;
		}
	}
}
