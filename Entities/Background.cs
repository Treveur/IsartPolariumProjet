using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class Background:AEntity
	{
		public Background (AScene scene) : base(scene)
		{
		}

		public override void Initialize()
		{
			
			base.Initialize ();
		}

		public override void LoadContent()
		{
			LinkSprite (new Sprite("background"));
			//sprite.color = Color.White;
			sprite.scale = 0.5f;
			sprite.depth = 1f;
			base.LoadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			Position = new Vector2 (_scene.sceneManager.graphics.PreferredBackBufferWidth / 2, _scene.sceneManager.graphics.PreferredBackBufferHeight / 2);
			base.Update (gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}

