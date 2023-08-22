using System;
using UnityEngine;
using QFramework;

namespace BallDemo
{
	public partial class Ball : ViewController
	{
		private const float speed = 5;
		private Vector2 velocity;
		private bool isCollision;
		
		public void OnInit(Vector2 dir)
		{
			velocity = dir;
			isCollision = false;
		}

		private void Update()
		{
			rb.velocity = velocity.normalized * speed;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Wall"))
			{
				velocity = Vector2.Reflect(velocity, other.GetContact(0).normal);
			}
			else if (other.gameObject.CompareTag("Ball"))
			{
				velocity = Vector2.Reflect(velocity, other.GetContact(0).normal);
			}
			else if (other.gameObject.CompareTag("DeadLine"))
			{
				Destroy(gameObject);
			}
			else if (other.gameObject.CompareTag("Brick"))
			{
				if (isCollision)
				{
					return;
				}
				isCollision = true;
				ActionKit.DelayFrame(1, () =>
				{
					isCollision = false;
				}).Start(this);
				velocity = Vector2.Reflect(velocity, other.GetContact(0).normal);
				other.gameObject.GetComponent<Brick>().BeAtk(1f);
			}
		}
	}
}
