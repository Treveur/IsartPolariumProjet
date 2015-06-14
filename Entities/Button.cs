using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class Button : AEntity
	{
		public bool _state;
		string specialTexLink;

		public bool changed;

		public Button (AScene scene, string link) : base(scene)
		{
			specialTexLink = link;
		}

		public override void Initialize()
		{
			_state = true;
			base.Initialize ();
		}

		public override void LoadContent()
		{
			LinkSprite (specialTexLink);
			sprite.color = Color.White;
			sprite.scale = 0.5f;
			sprite.depth = 0.1f;
			base.LoadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			if (AdvancedMouse.OnClic() && hitBox.Intersects (AdvancedMouse.hitBox)) {
				_state = !_state;
				changed = true;
				if (_state)
					sprite.color = Color.White;
				else
					sprite.color = Color.Red;
			}
			base.Update (gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}





















