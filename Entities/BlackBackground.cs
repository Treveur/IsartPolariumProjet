using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class BlackBackground:AEntity
	{
		public BlackBackground (AScene scene) : base(scene)
		{
		}

		public override void Initialize()
		{

			base.Initialize ();
		}

		public override void LoadContent()
		{
			LinkSprite (new Sprite("blackPauseMenu"));
			sprite.scale = 0.5f;
			sprite.depth = 0.4f;
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