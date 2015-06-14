using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsartPolarium
{
	public class Player : AEntity
	{
		public static Vector2 activePos = new Vector2();
		public Player (AScene scene) : base(scene)
		{
		}

		public override void Initialize()
		{
			base.Initialize ();
		}

		public override void LoadContent()
		{
			LinkSprite ("Character_Front", 1, 4, 4, 250);
			sprite.scale = 1f;
			sprite.position = new Vector2 (_scene.sceneManager.graphics.PreferredBackBufferWidth / 2, _scene.sceneManager.graphics.PreferredBackBufferHeight / 2);
			sprite.depth = 0f;
			base.LoadContent ();
		}

		public override void Update(GameTime gameTime)
		{

			//Console.WriteLine ("" + activePos.X);
			if (AdvancedMouse.OnClic ())
				sprite.color = Color.Red;
			else if (AdvancedMouse.OnDrag ())
				sprite.position = new Vector2 (Mouse.GetState ().Position.X, Mouse.GetState ().Position.Y);
			else if (AdvancedMouse.OnRelease ())
				sprite.color = Color.White;
			sprite.position = activePos;
			base.Update (gameTime);

		}
		public static void MovePlayer(Vector2 pos)
		{
			//Permet de déterminer la position du Character
			activePos = new Vector2(pos.X,pos.Y - 20);
			Console.WriteLine (pos.X);
		}
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}
