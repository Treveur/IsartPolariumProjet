using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsartPolarium
{
	public class DefeatSprite : AEntity
	{

		// Position du Player
		public static Vector2 activePos = new Vector2();
		public DefeatSprite (AScene scene) : base(scene)
		{
		}
			

		public override void Initialize()
		{
			base.Initialize ();
		}


		public override void LoadContent()
		{
			LinkSprite ("Sprite_DEFEAT");
			sprite.scale = 1f;
			sprite.position = new Vector2 (_scene.sceneManager.graphics.PreferredBackBufferWidth / 2, (_scene.sceneManager.graphics.PreferredBackBufferHeight / 2) - 150);
			sprite.depth = 0f;

			base.LoadContent ();
		}


		public override void Update(GameTime gameTime)
		{
			base.Update (gameTime);
		}
			
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}
